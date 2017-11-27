using System;
using System.Collections.Generic;
using UnityEngine;
using CourseToEarth.Pooling;

namespace CourseToEarth.Managers
{
  /// <summary>
  /// Object pooling for reusing instances and improve performance
  /// </summary>
  public class PoolManager : Singleton<PoolManager>
  {
    /**********************************************************************************************/
    /*  Members                                                                                   */
    /**********************************************************************************************/
    #region Members


    [System.Serializable]
    private class PrefabItem
    {
      public PoolObject.PoolObjectType poolType;
      public int poolSize = 0;
      public GameObject poolItem;
    }

    [SerializeField]
    private PrefabItem[] prefabItems;

    private Dictionary<PoolObject.PoolObjectType, Pool> pools;
    private Transform poolRoot;

    #endregion

    /**********************************************************************************************/
    /*  Public Methods                                                                            */
    /**********************************************************************************************/
    #region Public methods

    public void InitAllPools()
    {
      poolRoot = new GameObject(ConstantData.Strings.Pool).transform;
      pools = new Dictionary<PoolObject.PoolObjectType, Pool>();
      for (int i = 0; i < prefabItems.Length; i++)
      {
        Transform parent = CreatePoolSceneParent(prefabItems[i].poolType);
        parent.parent = poolRoot;
        InitPoolOfType(prefabItems[i], parent);
      }
    }

    public PoolObject GetPoolObjectOfType(PoolObject.PoolObjectType pooltype, Vector3 initialPosition)
    {
      if (pools.ContainsKey(pooltype))
      {
        Pool pool = pools[pooltype];
        if (pool.FreeObjects.Count > 0)
        {
          PoolObject poolObject = pool.FreeObjects[0];
          poolObject.GetPoolObject(initialPosition);
          pool.FreeObjects.Remove(poolObject);
          pool.UsedObjects.Add(poolObject);
          return poolObject;
        }
      }
      return null;
    }

    public void ReleasePoolObject(PoolObject poolObject)
    {
      poolObject.ReleasePoolObject();
      pools[poolObject.ObjectType].UsedObjects.Remove(poolObject);
      pools[poolObject.ObjectType].FreeObjects.Add(poolObject);
    }

    public Renderer GetBiggestSpawnRenderer()
    {
      for (int i = 0; i < prefabItems.Length; i++)
      {
        if (prefabItems[i].poolType == PoolObject.PoolObjectType.SpecialStar)
        {
          return prefabItems[i].poolItem.GetComponent<Renderer>();
        }
      }
      return null;
    }

    #endregion

    /**********************************************************************************************/
    /*  Private Methods                                                                           */
    /**********************************************************************************************/
    #region Private methods

    private Transform CreatePoolSceneParent(PoolObject.PoolObjectType poolObjectType)
    {
      return new GameObject(poolObjectType + ConstantData.Strings.Pool).transform;
    }

    private void InitPoolOfType(PrefabItem prefabItem, Transform parent)
    {
      PoolObject instantiatedPoolObject;
      List<PoolObject> instantiatedPoolObjects = new List<PoolObject>();
      for (int i = 0; i < prefabItem.poolSize; i++)
      {
        instantiatedPoolObject = GameObject.Instantiate(prefabItem.poolItem, parent).GetComponent<PoolObject>();
        instantiatedPoolObject.ObjectType = prefabItem.poolType;
        instantiatedPoolObject.ReleasePoolObject();
        instantiatedPoolObjects.Add(instantiatedPoolObject);
      }
      pools.Add(prefabItem.poolType, new Pool(instantiatedPoolObjects));
    }

    #endregion

  }
}