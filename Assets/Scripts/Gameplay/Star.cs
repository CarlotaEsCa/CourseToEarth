using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.Pooling;
using CourseToEarth.Managers;

/// <summary>
/// Star and Special Star constant movement in a specified direction
/// </summary>
public class Star : PoolObject
{

  /**********************************************************************************************/
  /*  Members                                                                                   */
  /**********************************************************************************************/
  #region Members

  private Transform cachedTransform;
  private Vector3 transformDirection;
  private float velocity;

  #endregion

  /**********************************************************************************************/
  /*  MonoBehaviour Methods                                                                     */
  /**********************************************************************************************/
  #region MonoBehaviour Methods

  void Update()
  {
    cachedTransform.localPosition += transformDirection * velocity;
  }

  #endregion

  /**********************************************************************************************/
  /*  Public Methods                                                                            */
  /**********************************************************************************************/
  #region Public methods

  public void Init(float velocity, float angle)
  {
    cachedTransform = this.transform;
    this.velocity = velocity;
    cachedTransform.eulerAngles = ConstantData.Vectors.ZComponentModifier * angle;
    transformDirection = cachedTransform.TransformDirection(ConstantData.Vectors.VectorDown);
  }

  #endregion

}
