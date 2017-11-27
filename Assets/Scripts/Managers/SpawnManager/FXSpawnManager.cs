using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.Pooling;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Controls all the effects from the object pool
  /// </summary>
  public class FXSpawnManager : MonoBehaviour
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members
    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void OnEnable()
    {
      InputManager.OnStarClick += SpawnStarExplosion;
      InputManager.OnSpecialStarClick += SpawnStarExplosion;
      AnimationEventController.OnAnimationEnded += ReleaseStarExplosion;
    }

    void OnDisable()
    {
      InputManager.OnStarClick -= SpawnStarExplosion;
      InputManager.OnSpecialStarClick -= SpawnStarExplosion;
      AnimationEventController.OnAnimationEnded -= ReleaseStarExplosion;
    }

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods
    #endregion

    /**********************************************************************************************/
    /*  Protected Methods                                                                         */
    /**********************************************************************************************/
    #region Protected methods
    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void SpawnStarExplosion(GameObject starReleased)
    {
      PoolManager.Instance.GetPoolObjectOfType(PoolObject.PoolObjectType.StarExplosion, starReleased.transform.position).gameObject.GetComponent<AnimationEventController>();
    }

    private void ReleaseStarExplosion(PoolObject poolObject)
    {
      PoolManager.Instance.ReleasePoolObject(poolObject);
    }

    #endregion

  }
}


