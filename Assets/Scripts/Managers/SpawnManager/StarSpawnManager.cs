using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.Pooling;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Spawns stars and special stars in game
  /// </summary>
  public class StarSpawnManager : MonoBehaviour
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    private List<Star> currentStars;
    private float nextStarSpawnTime;
    private float nextSpecialStarSpawnTime;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Start()
    {
      currentStars = new List<Star>();
      ScreenBoundsManager.Instance.SetScreenLimits(PoolManager.Instance.GetBiggestSpawnRenderer());
    }

    void Update()
    {
      if (GameManager.Instance.GameCurrentState == GameManager.GameState.Playing)
      {
        if (CanSpawnSpecialStar())
        {
          SpawnSpecialStar(GetSpawnPosition());
        }
        else if (CanSpawnNewStar())
        {
          SpawnStar(GetSpawnPosition());
        }
      }
    }

    void OnEnable()
    {
      StarLimits.OnStarCollision += ReleaseStar;
      UIManager.OnClickNewGameEventHandler += SetNewTimes;
      GameManager.OnGameEnd += ReleaseAllStars;
      InputManager.OnSpecialStarClick += ReleaseSpecialStar;
      InputManager.OnStarClick += ReleaseStar;
    }

    void OnDisable()
    {
      StarLimits.OnStarCollision -= ReleaseStar;
      UIManager.OnClickNewGameEventHandler -= SetNewTimes;
      GameManager.OnGameEnd -= ReleaseAllStars;
      InputManager.OnSpecialStarClick -= ReleaseSpecialStar;
      InputManager.OnStarClick -= ReleaseStar;
    }
    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void SpawnStar(Vector3 spawnPosition)
    {
      Star newStar = PoolManager.Instance.GetPoolObjectOfType(PoolObject.PoolObjectType.SimpleStar, spawnPosition) as Star;
      newStar.Init(GetRandomVelocity(), GetRandomAngle(spawnPosition.x));
      currentStars.Add(newStar);
      nextStarSpawnTime = Time.time + GameDataManager.Instance.GetRandomStarSpawnTime();
    }

    private void SpawnSpecialStar(Vector3 spawnPosition)
    {
      Star newStar = PoolManager.Instance.GetPoolObjectOfType(PoolObject.PoolObjectType.SpecialStar, spawnPosition) as Star;
      newStar.Init(GetRandomVelocity(), GetRandomAngle(spawnPosition.x));
      currentStars.Add(newStar);
      nextStarSpawnTime = Time.time + GameDataManager.Instance.GetRandomStarSpawnTime();
      nextSpecialStarSpawnTime = Time.time + GameDataManager.Instance.GetRandomSpecialStarSpawnTime();
    }

    private bool CanSpawnNewStar()
    {
      return Time.time > nextStarSpawnTime;
    }

    private bool CanSpawnSpecialStar()
    {
      return Time.time > nextSpecialStarSpawnTime;
    }

    private void ReleaseStar(GameObject star)
    {
      Star releaseStar = star.GetComponent<Star>();
      PoolManager.Instance.ReleasePoolObject(releaseStar);
      currentStars.Remove(releaseStar);
    }

    private void ReleaseSpecialStar(GameObject gameObject)
    {
      Star releaseStar = gameObject.GetComponent<Star>();
      PoolManager.Instance.ReleasePoolObject(releaseStar);
      currentStars.Remove(releaseStar);
      SpawnStar(GetSecondStarSpawnPosition(releaseStar.transform.position, ConstantData.Vectors.VectorLeft));
      SpawnStar(GetSecondStarSpawnPosition(releaseStar.transform.position, ConstantData.Vectors.VectorRight));
    }

    private Vector3 GetSpawnPosition()
    {
      return new Vector2(Random.Range(-ScreenBoundsManager.Instance.MaxWidth, ScreenBoundsManager.Instance.MaxWidth), this.transform.position.y);
    }

    private void ReleaseAllStars()
    {
      for (int i = currentStars.Count - 1; i >= 0; i--)
      {
        ReleaseStar(currentStars[i].gameObject);
      }
    }

    private float GetRandomVelocity()
    {
      return GameDataManager.Instance.GetRandomVelocity();
    }

    private float GetRandomAngle(float currentPosition)
    {
      if (ScreenBoundsManager.Instance.IsInsideMiddleScreen(currentPosition))
      {
        return GameDataManager.Instance.GetRandomMiddleScreenAngle();
      }
      else
      {
        return Mathf.Sign(-currentPosition) * GameDataManager.Instance.GetRandomSideScreenAngle();
      }
    }

    private Vector3 GetSecondStarSpawnPosition(Vector3 specialStarPosition, Vector3 direction)
    {
      Vector3 newVector = specialStarPosition + (direction * GameDataManager.Instance.GetSecondStarSpawnSpace());
      Mathf.Clamp(newVector.x, -ScreenBoundsManager.Instance.MaxWidth, ScreenBoundsManager.Instance.MaxWidth);
      return newVector;
    }

    private void SetNewTimes()
    {
      nextStarSpawnTime = Time.time + GameDataManager.Instance.GetRandomStarSpawnTime();
      nextSpecialStarSpawnTime = Time.time + GameDataManager.Instance.GetRandomSpecialStarSpawnTime();
    }

    #endregion
  }
}
