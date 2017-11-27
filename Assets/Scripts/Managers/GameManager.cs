using System;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Controls win/lose conditions and game state
  /// </summary>
  public class GameManager : Singleton<GameManager>
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    public static System.Action OnGameEnd = delegate { };

    public enum GameState
    {
      Stopped,
      Playing
    }

    public GameState GameCurrentState
    {
      get
      {
        return gameCurrentState;
      }
    }

    private GameState gameCurrentState = GameState.Playing;
    private float timeLeft;
    private int lives;
    private int score;
    private int scoreStreak;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Start()
    {
      PoolManager.Instance.InitAllPools();
      gameCurrentState = GameState.Stopped;
    }

    void Update()
    {
      if (gameCurrentState == GameState.Playing)
      {
        timeLeft -= Time.deltaTime;
        UIManager.Instance.UpdateClock(timeLeft);
        CheckGame();
      }
    }

    void OnEnable()
    {
      UIManager.OnClickNewGameEventHandler += StartGame;
      StarLimits.OnStarCollision += LoseLife;
      InputManager.OnStarClick += UpdateScore;
      InputManager.OnSpecialStarClick += UpdateScore;
    }

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
      UIManager.OnClickNewGameEventHandler -= StartGame;
      StarLimits.OnStarCollision -= LoseLife;
      InputManager.OnStarClick -= UpdateScore;
      InputManager.OnSpecialStarClick -= UpdateScore;
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void StartGame()
    {
      gameCurrentState = GameState.Playing;
      lives = 5;
      score = 0;
      ResetScoreStreak();
      timeLeft = GameDataManager.Instance.RoundSeconds;
      UIManager.Instance.StartNewGame(timeLeft);
    }

    private void LoseLife(GameObject star)
    {
      lives--;
      ResetScoreStreak();
      CheckGame();
    }

    private void CheckGame()
    {
      if (lives == 0 || timeLeft <= 0.0f)
      {
        EndGame();
      }
    }

    private void EndGame()
    {
      OnGameEnd();
      UIManager.Instance.EndGame(score);
      gameCurrentState = GameState.Stopped;
    }

    private void UpdateScore(GameObject star)
    {
      score += GameDataManager.Instance.HitStarPoints * scoreStreak;
      scoreStreak++;
      UIManager.Instance.UpdateScore(score);
    }

    private void ResetScoreStreak()
    {
      scoreStreak = 1;
    }

    #endregion
  }
}