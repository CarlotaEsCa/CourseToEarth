using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Transform Tweener for Rect Transform animations
  /// </summary>
  public abstract class TransformTweener : Tweener
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    protected RectTransform cachedRectTransform;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Awake()
    {
      cachedRectTransform = transform as RectTransform;
    }

    #endregion

  }
}