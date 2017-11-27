using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Rotation Tweener to animate UI transforms
  /// </summary>
  public class RotationTweener : TransformTweener
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private float initialRotation;

    [SerializeField]
    private float finalRotation;

    #endregion

    /**********************************************************************************************/
    /*  Protected Methods                                                                         */
    /**********************************************************************************************/
    #region Protected methods

    protected override void UpdateTransform(float curveValue)
    {
      cachedRectTransform.localEulerAngles = ConstantData.Vectors.ZComponentModifier * Mathf.Lerp(initialRotation, finalRotation, curveValue);
    }

    #endregion

  }
}