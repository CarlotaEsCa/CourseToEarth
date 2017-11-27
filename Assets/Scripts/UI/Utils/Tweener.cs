﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.UI
{
  /// <summary>
  /// Tweener Utility to animate UI elements
  /// </summary>
  public abstract class Tweener : MonoBehaviour
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

    [SerializeField]
    private bool playOnStart;

    [SerializeField]
    private AnimationCurve tweenerCurve;

    [SerializeField]
    private TweenerType tweenerType;

    [SerializeField]
    private float startDelay;

    [SerializeField]
    private float duration;

    private float currentTime;

    private System.Action onFinishedCallback = delegate { };

    private enum TweenerType
    {
      Once,
      Loop
    }

    #endregion

    /**********************************************************************************************/
    /*  MonoBehaviour Methods                                                                     */
    /**********************************************************************************************/
    #region MonoBehaviour Methods

    void OnEnable()
    {
      if (playOnStart)
      {
        PlayTweener();
      }
    }

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void AddOnFinishedCallback(System.Action callback)
    {
      onFinishedCallback = callback;
    }

    public void RemoveOnFinishedCallback()
    {
      onFinishedCallback = null;
    }

    public void PlayTweener()
    {
      StartCoroutine(EvaluateTweener());
    }

    public void ResetTweener()
    {
      StopCoroutine(EvaluateTweener());
      UpdateTransform(0);
    }

    #endregion

    /**********************************************************************************************/
    /*  Protected Methods                                                                         */
    /**********************************************************************************************/
    #region Protected methods

    protected abstract void UpdateTransform(float curveValue);

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private IEnumerator EvaluateTweener()
    {
      do
      {
        UpdateTransform(tweenerCurve.Evaluate(0));
        yield return new WaitForSeconds(startDelay);
        currentTime = 0;
        while (currentTime < duration)
        {
          UpdateTransform(tweenerCurve.Evaluate(currentTime / duration));
          currentTime += Time.deltaTime;
          yield return null;
        }
        UpdateTransform(tweenerCurve.Evaluate(1));

        onFinishedCallback();
      } while (tweenerType == TweenerType.Loop);
    }

    #endregion

  }
}