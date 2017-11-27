using UnityEngine;

[CreateAssetMenu(fileName = "Audio Settings")]
public class AudioSettings : ScriptableObject
{
  [Header("Audio Clips")]
  public AudioClip uiButton;

  public AudioClip starDestroyed;

  public AudioClip loseLife;

}
