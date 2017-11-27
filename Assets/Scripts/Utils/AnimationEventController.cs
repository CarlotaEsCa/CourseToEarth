using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.Pooling;

public class AnimationEventController : PoolObject
{

  /**********************************************************************************************/
  /*  Members                                                                                   */
  /**********************************************************************************************/
  #region Members

  public static System.Action<PoolObject> OnAnimationEnded = delegate { };

  #endregion

  /**********************************************************************************************/
  /*  Public Methods                                                                            */
  /**********************************************************************************************/
  #region Public methods

  public void OnEndAnimation()
  {
    NotifyAnimationEndHandler();
  }

  #endregion

  /**********************************************************************************************/
  /*  Private Methods                                                                           */
  /**********************************************************************************************/
  #region Private methods

  private void NotifyAnimationEndHandler()
  {
    OnAnimationEnded(this);
  }

  #endregion
}
