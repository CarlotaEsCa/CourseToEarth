using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Main Menu UI view
  /// </summary>
  public class MainMenuPanelScreenView : ScreenView
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private Button playButton;

    private System.Action playButtonCallback = delegate { };

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void SubscribeNewGameButton(System.Action callback)
    {
      playButtonCallback = callback;
      playButton.onClick.AddListener(OnPlayButtonClick);
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void OnPlayButtonClick()
    {
      playButtonCallback();
    }
    #endregion

  }
}