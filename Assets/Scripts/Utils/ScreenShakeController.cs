using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{

  /**********************************************************************************************/
  /*  Members                                                                                   */
  /**********************************************************************************************/
  #region Members

  [SerializeField]
  private float duration = 2f;

  [SerializeField]
  private float frequency = 10.0f;

  [SerializeField]
  private float magnitude = 0.5f;

  private Transform cachedTransform;
  private Vector3 cachedVector;
  private Vector3 initialPosition;
  private float currentTime = 0;
  private float seed;
  #endregion

  /**********************************************************************************************/
  /*  MonoBehaviour Methods                                                                     */
  /**********************************************************************************************/
  #region MonoBehaviour Methods

  void OnEnable()
  {
    cachedTransform = this.transform;
    initialPosition = this.transform.position;
    StarLimits.OnStarCollision += StartShakeScreen;
  }

  void OnDisable()
  {
    StarLimits.OnStarCollision -= StartShakeScreen;
  }
  #endregion

  /**********************************************************************************************/
  /*  Private Methods                                                                           */
  /**********************************************************************************************/
  #region Private methods

  public void StartShakeScreen(GameObject star)
  {
    StartCoroutine(ShakeScreen());
  }

  private IEnumerator ShakeScreen()
  {
    currentTime = 0;
    while (currentTime < duration)
    {
      seed = Time.time * frequency;
      cachedVector = new Vector3(Mathf.PerlinNoise(seed, 0.0f) * magnitude, Mathf.PerlinNoise(0.0f, seed) * magnitude, transform.position.z);
      cachedTransform.position = cachedVector;
      currentTime += Time.deltaTime;
      yield return null;
    }

    cachedTransform.position = Vector3.Lerp(cachedTransform.position, initialPosition, 0.5f);
    yield return null;
    cachedTransform.position = initialPosition;
  }
  #endregion
}
