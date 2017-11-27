using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.UI
{
  /// <summary>
  /// UI base class for panels
  /// </summary>
  public class ScreenView : MonoBehaviour
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members
    [SerializeField]
    protected GameObject root;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods
    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void EnableRoot(bool enabled)
    {
      root.SetActive(enabled);
    }

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
    #endregion

  }
}


