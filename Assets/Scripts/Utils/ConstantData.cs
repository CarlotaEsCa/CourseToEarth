using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantData
{
  public static class Strings
  {
    public const string EmptyString = "";
    public const string StarTag = "Star";
    public const string SpecialStarTag = "SpecialStar";
    public const string Pool = "Pool";
    public const string AudioSource = "AudioSource";
  }

  public static class Vectors
  {
    public static readonly Vector3 VectorDown = Vector3.down;
    public static readonly Vector3 VectorLeft = Vector3.left;
    public static readonly Vector3 VectorRight = Vector3.right;

    public static readonly Vector3 ZComponentModifier = new Vector3(0, 0, 1);
  }
}
