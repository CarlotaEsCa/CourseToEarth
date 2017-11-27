using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Position Tweener to animate UI transforms
  /// </summary>
  public class PositionTweener : TransformTweener
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private Vector3 initialPosition;

    [SerializeField]
    private Vector3 finalPosition;
    #endregion

    /**********************************************************************************************/
    /*  Protected Methods                                                                         */
    /**********************************************************************************************/
    #region Protected methods

    protected override void UpdateTransform(float curveValue)
    {
      cachedRectTransform.anchoredPosition = Vector3.Lerp(initialPosition, finalPosition, curveValue);
    }

    #endregion
  }
}