using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CourseToEarth.Pooling
{
  /// <summary>
  /// Class purpose
  /// </summary>
  public class Pool : MonoBehaviour
  {

    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members

		public List<PoolObject> FreeObjects
		{
			get
			{
				return freeObjects;
			}
		}

		public List<PoolObject> UsedObjects
		{
			get
			{
				return usedObjects;
			}
		}
		private List<PoolObject> freeObjects;
		private List<PoolObject> usedObjects;

    #endregion

    /**********************************************************************************************/
    /*  Constructor                                                                               */
    /**********************************************************************************************/
    #region Constructor

		public Pool(List<PoolObject> initialPool)
		{
			freeObjects = initialPool;
			usedObjects = new List<PoolObject>();
		}

    #endregion
  }
}


