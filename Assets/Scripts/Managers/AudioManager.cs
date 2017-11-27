using System;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Plays all sounds in the game
  /// </summary>
  public class AudioManager : Singleton<AudioManager>
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private Transform audioParent;

    private AudioSettings audioSettings;
    private List<AudioSource> audioSourcePool;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Start()
    {
      audioSettings = Resources.Load("Audio Settings") as AudioSettings;
      audioSourcePool = new List<AudioSource>();
    }

    void OnEnable()
    {
      InputManager.OnStarClick += PlayStarDestroyedSound;
      InputManager.OnStarClick += PlayStarDestroyedSound;
      StarLimits.OnStarCollision += PlayLoseLifeSound;
      UIManager.OnClickNewGameEventHandler += PlayUIButtonSound;
    }

    void OnDisable()
    {
      InputManager.OnStarClick -= PlayStarDestroyedSound;
      InputManager.OnStarClick -= PlayStarDestroyedSound;
      StarLimits.OnStarCollision -= PlayLoseLifeSound;
      UIManager.OnClickNewGameEventHandler -= PlayUIButtonSound;
    }

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods


    public void PlayUIButtonSound()
    {
      Play(audioSettings.uiButton);
    }

    public void PlayStarDestroyedSound(GameObject gameObject)
    {
      Play(audioSettings.starDestroyed);
    }

    public void PlayLoseLifeSound(GameObject star)
    {
      Play(audioSettings.loseLife);
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void Play(AudioClip audioClip)
    {
      foreach (AudioSource instantiatedAudioSource in audioSourcePool)
      {
        if (!instantiatedAudioSource.isPlaying)
        {
          PlayAudioClip(instantiatedAudioSource, audioClip);
          return;
        }
      }
      AudioSource audioSource = InstantiateAudioSource();
      PlayAudioClip(audioSource, audioClip);
    }

    private void PlayAudioClip(AudioSource audioSource, AudioClip audioClip)
    {
      audioSource.clip = audioClip;
      audioSource.Play();
    }

    private AudioSource InstantiateAudioSource()
    {
      AudioSource audioSource = new GameObject(ConstantData.Strings.AudioSource).AddComponent<AudioSource>();
      audioSourcePool.Add(audioSource);
      audioSource.transform.parent = audioParent;
      return audioSource;
    }

    #endregion

  }
}