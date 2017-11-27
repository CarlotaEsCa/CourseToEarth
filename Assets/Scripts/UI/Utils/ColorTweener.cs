using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Color Tweener to animate color elements
  /// </summary>
  public class ColorTweener : Tweener
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private Color initialColor;

    [SerializeField]
    private Color finalColor;

    private MaskableGraphic colorComponent;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Awake()
    {
      colorComponent = GetComponent<MaskableGraphic>();
    }

    #endregion

    /**********************************************************************************************/
    /*  Protected Methods                                                                         */
    /**********************************************************************************************/
    #region Protected methods

    protected override void UpdateTransform(float curveValue)
    {
      colorComponent.color = Color.Lerp(initialColor, finalColor, curveValue);
    }

    #endregion
  }
}