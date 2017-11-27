using System;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Detects all inputs needed for the game
  /// </summary>
  public class InputManager : Singleton<InputManager>
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    public static System.Action<GameObject> OnStarClick = delegate { };
    public static System.Action<GameObject> OnSpecialStarClick = delegate { };

    private Camera mainCamera;
    private RaycastHit2D raycastHitCached;
    private Dictionary<string, System.Action<GameObject>> tagsActionsDictionary;

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void Start()
    {
      mainCamera = Camera.main;
      tagsActionsDictionary = new Dictionary<string, Action<GameObject>>();
      tagsActionsDictionary.Add(ConstantData.Strings.StarTag, s => OnStarClick(s));
      tagsActionsDictionary.Add(ConstantData.Strings.SpecialStarTag, s => OnSpecialStarClick(s));
    }

    void Update()
    {
#if UNITY_EDITOR
      if (Input.GetMouseButtonDown(0))
      {
        OnTouchDetected(Input.mousePosition);
      }
#else
      for (int touchIndex = 0; touchIndex < Input.touchCount; ++touchIndex)
      {
        if (Input.touches[touchIndex].phase == TouchPhase.Began)
        {
          OnTouchDetected(Input.touches[touchIndex]);
        }
      }
#endif
    }
    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private void OnTouchDetected(Vector3 clickPosition)
    {
      if (raycastHitCached = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(clickPosition), Vector3.zero))
      {
        if (tagsActionsDictionary.ContainsKey(raycastHitCached.collider.tag))
        {
          tagsActionsDictionary[raycastHitCached.collider.tag](raycastHitCached.collider.gameObject);
        }
      }
    }

    #endregion

  }
}