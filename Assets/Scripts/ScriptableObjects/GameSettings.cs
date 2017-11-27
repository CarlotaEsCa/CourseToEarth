using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings")]
public class GameSettings : ScriptableObject
{
  [Header("Game Values")]
  public float minimumSpeed;
  public float maximumSpeed;

  [Space(10)]
  public float minimumStarSpawnTime;
  public float maximumStarSpawnTime;

  [Space(10)]
  public float secondStarSpawnSpace;
  public float minimumSpecialStarSpawnTime;
  public float maximumSpecialStarSpawnTime;

  [Space(10)]
  public float increasingSpeed;
  public float increasingTime;

  [Space(10)]
  public float roundSeconds;
  public int hitStarPoints;

  [Header("Star Settings")]
  public float middleScreenAngle;
  public float sideScreenAngle;
}
