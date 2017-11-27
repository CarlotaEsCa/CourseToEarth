using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CourseToEarth.UI
{
  /// <summary>
  /// End Game UI view
  /// </summary>
  public class EndGamePanelScreenView : ScreenView
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Button playAgainButton;

    private System.Action playAgainButtonCallback = delegate { };
    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void Init(int score, System.Action callback)
    {
      SetScore(score);
      SubscribeRestartGameButton(callback);
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void OnPlayAgainButtonClick()
    {
      playAgainButtonCallback();
    }

    private void SubscribeRestartGameButton(System.Action callback)
    {
      playAgainButtonCallback = callback;
      playAgainButton.onClick.AddListener(OnPlayAgainButtonClick);
    }

    private void SetScore(int score)
    {
      scoreText.text = score.ToString();
    }

    #endregion
  }
}