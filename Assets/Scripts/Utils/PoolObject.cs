using System;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.Pooling
{
  /// <summary>
  /// Object which can be pooled
  /// </summary>
  public class PoolObject : MonoBehaviour
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    public enum PoolObjectType
    {
      SimpleStar,
      SpecialStar,
      StarExplosion
    };

    public PoolObjectType ObjectType
    {
      get;
      set;
    }

    private PoolObjectType poolObjectType;

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void GetPoolObject(Vector3 initialPosition)
    {
      gameObject.SetActive(true);
      transform.position = initialPosition;
    }

    public void ReleasePoolObject()
    {
      gameObject.SetActive(false);
    }
    #endregion

  }
}