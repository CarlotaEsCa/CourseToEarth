using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.Pooling;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Stores data related with screen size
  /// </summary>
  public class ScreenBoundsManager : Singleton<ScreenBoundsManager>
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    public float MaxWidth
    {
      get
      {
        return maxWidth;
      }
    }

    public float MaxHeight
    {
      get;
    }

    private float maxWidth;
    private float maxHeight;

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void SetScreenLimits(Renderer referenceRenderer)
    {
      Camera camera = Camera.main;
      Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
      maxWidth = camera.ScreenToWorldPoint(upperCorner).x;
      float objectWidth = referenceRenderer.bounds.extents.x;
      maxWidth -= objectWidth;
    }

    public bool IsInsideMiddleScreen(float widthPosition)
    {
      return widthPosition < maxWidth / 2 && widthPosition > -maxWidth / 2;
    }

    #endregion
  }
}
