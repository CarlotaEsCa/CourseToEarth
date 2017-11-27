using System;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.UI;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Manages transition between UI panels
  /// </summary>
  public class UIManager : Singleton<UIManager>
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    public static System.Action OnClickNewGameEventHandler = delegate { };

    [SerializeField]
    private MainMenuPanelScreenView mainMenuPanelScreenView;

    [SerializeField]
    private GamePanelScreenView gamePanelScreenView;

    [SerializeField]
    private EndGamePanelScreenView endGamePanelScreenView;

    private List<ScreenView> screenViewList;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Start()
    {
      screenViewList = new List<ScreenView>();
      screenViewList.Add(mainMenuPanelScreenView);
      screenViewList.Add(gamePanelScreenView);
      screenViewList.Add(endGamePanelScreenView);

      InitGame();
    }
    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void InitGame()
    {
      DisableAllViews();
      mainMenuPanelScreenView.EnableRoot(true);
      mainMenuPanelScreenView.SubscribeNewGameButton(OnClickNewGameEventHandler);
    }

    public void StartNewGame(float roundSeconds)
    {
      DisableAllViews();
      gamePanelScreenView.EnableRoot(true);

      gamePanelScreenView.ResetGameplayUI(roundSeconds);
    }

    public void EndGame(int score)
    {
      endGamePanelScreenView.EnableRoot(true);

      endGamePanelScreenView.Init(score, OnClickNewGameEventHandler);
    }

    public void UpdateClock(float timeLeft)
    {
      gamePanelScreenView.UpdateClock(Mathf.RoundToInt(timeLeft));
    }

    public void UpdateScore(int score)
    {
      gamePanelScreenView.UpdateScore(score);
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void DisableAllViews()
    {
      foreach (ScreenView screenView in screenViewList)
      {
        screenView.EnableRoot(false);
      }
    }

    #endregion
  }
}