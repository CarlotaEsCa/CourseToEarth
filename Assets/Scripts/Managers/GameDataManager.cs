using System;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Stores all game data
  /// </summary>
  public class GameDataManager : Singleton<GameDataManager>
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    public int HitStarPoints
    {
      get
      {
        return gameSettings.hitStarPoints;
      }
    }

    public float RoundSeconds
    {
      get
      {
        return gameSettings.roundSeconds;
      }
    }

    private GameSettings gameSettings;
    private float minimumSpeed;
    private float maximumSpeed;
    private float minimumStarSpawnTime;
    private float maximumStarSpawnTime;
    private float minimumSpecialStarSpawnTime;
    private float maximumSpecialStarSpawnTime;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    protected void Awake()
    {
      base.Awake();
      gameSettings = Resources.Load("Game Settings") as GameSettings;
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void OnEnable()
    {
      UIManager.OnClickNewGameEventHandler += SetGameParameters;
    }

    void OnDisable()
    {
      UIManager.OnClickNewGameEventHandler -= SetGameParameters;
    }

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods
    public float GetRandomVelocity()
    {
      return UnityEngine.Random.Range(minimumSpeed, maximumSpeed);
    }

    public float GetSecondStarSpawnSpace()
    {
      return gameSettings.secondStarSpawnSpace;
    }

    public float GetRandomStarSpawnTime()
    {
      IncreaseParamaters();
      return UnityEngine.Random.Range(minimumStarSpawnTime, maximumStarSpawnTime);
    }

    public float GetRandomSpecialStarSpawnTime()
    {
      return UnityEngine.Random.Range(minimumSpecialStarSpawnTime, maximumSpecialStarSpawnTime);
    }

    public float GetRandomMiddleScreenAngle()
    {
      return UnityEngine.Random.Range(-gameSettings.middleScreenAngle, gameSettings.middleScreenAngle);
    }

    public float GetRandomSideScreenAngle()
    {
      return UnityEngine.Random.Range(0, gameSettings.sideScreenAngle);
    }

    public void IncreaseParamaters()
    {
      minimumSpeed += gameSettings.increasingSpeed;
      maximumSpeed += gameSettings.increasingSpeed;
      minimumStarSpawnTime -= gameSettings.increasingTime;
      maximumStarSpawnTime -= gameSettings.increasingTime;
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void SetGameParameters()
    {
      minimumSpeed = gameSettings.minimumSpeed;
      maximumSpeed = gameSettings.maximumSpeed;
      minimumStarSpawnTime = gameSettings.minimumStarSpawnTime;
      maximumStarSpawnTime = gameSettings.maximumStarSpawnTime;
      minimumSpecialStarSpawnTime = gameSettings.minimumSpecialStarSpawnTime;
      maximumSpecialStarSpawnTime = gameSettings.maximumSpecialStarSpawnTime;
    }

    #endregion

  }
}