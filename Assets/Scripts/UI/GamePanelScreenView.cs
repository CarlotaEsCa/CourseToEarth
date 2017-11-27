using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Gameplay UI view
  /// </summary>
  public class GamePanelScreenView : ScreenView
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private ColorTweener[] lifes;

    [SerializeField]
    private Text clockText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Image fillClock;

    [SerializeField]
    private ColorTweener damageMask;

    private int lostLifeIndex;
    private float roundSeconds;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void OnEnable()
    {
      StarLimits.OnStarCollision += LoseLife;
    }

    void OnDisable()
    {
      StarLimits.OnStarCollision -= LoseLife;
    }
    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void ResetGameplayUI(float roundSeconds)
    {
      ResetLifes();
      UpdateScore(0);
      ResetClock(roundSeconds);
    }

    public void ResetLifes()
    {
      for (int i = 0; i < lifes.Length; i++)
      {
        lifes[i].ResetTweener();
      }
      lostLifeIndex = lifes.Length;
    }

    public void ResetClock(float roundSeconds)
    {
      fillClock.fillAmount = 1;
      this.roundSeconds = roundSeconds;
    }

    public void UpdateClock(int timeLeft)
    {
      fillClock.fillAmount = timeLeft / roundSeconds;
      clockText.text = timeLeft.ToString();
    }

    public void UpdateScore(int score)
    {
      scoreText.text = score.ToString();
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void LoseLife(GameObject star)
    {
      lostLifeIndex--;
      if (lostLifeIndex >= 0)
      {
        lifes[lostLifeIndex].PlayTweener();
        damageMask.PlayTweener();
      }
    }

    #endregion

  }
}