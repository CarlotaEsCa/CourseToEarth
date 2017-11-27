using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Star collider under the screen
/// </summary>
public class StarLimits : MonoBehaviour
{

  /**********************************************************************************************/
  /*  Members                                                                                   */
  /**********************************************************************************************/
  #region Members

  // Events and delegates

  public static System.Action<GameObject> OnStarCollision = delegate { };

  #endregion

  /**********************************************************************************************/
  /*  MonoBehaviour Methods                                                                     */
  /**********************************************************************************************/
  #region MonoBehaviour Methods

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag(ConstantData.Strings.StarTag) || other.CompareTag(ConstantData.Strings.SpecialStarTag))
    {
      OnStarCollision(other.gameObject);
    }
  }

  #endregion

}