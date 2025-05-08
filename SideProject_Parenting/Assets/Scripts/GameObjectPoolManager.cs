using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Parenting.Scripts
{
    public class GameObjectPoolManager : MonoBehaviour
    {
        public static GameObjectPoolManager Instance { get; private set; }

        private Dictionary<string, ObjectPool<GameObject>> _pools = new();
        private Dictionary<GameObject, ObjectPool<GameObject>> _objectToPool = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// 預先建立一個物件池
        /// </summary>
        public void CreatePool(string key, GameObject prefab, int defaultCapacity = 10, int maxSize = 50)
        {
            if (_pools.ContainsKey(key)) return;

            ObjectPool<GameObject> tempPool = null;

            tempPool = new ObjectPool<GameObject>(
                createFunc: () =>
                {
                    var go = Instantiate(prefab);
                    _objectToPool[go] = tempPool;
                    return go;
                },
                actionOnGet: (go) => go.SetActive(true),
                actionOnRelease: (go) => go.SetActive(false),
                actionOnDestroy: Destroy,
                collectionCheck: false,
                defaultCapacity: defaultCapacity,
                maxSize: maxSize
            );

            _pools[key] = tempPool;
        }

        /// <summary>
        /// 從池中取出物件
        /// </summary>
        public GameObject Spawn(string key, Vector3 position, Quaternion rotation)
        {
            if (!_pools.TryGetValue(key, out var pool))
            {
                Debug.LogError($"[Pool] Pool with key '{key}' not found!");
                return null;
            }

            var go = pool.Get();
            go.transform.SetPositionAndRotation(position, rotation);
            return go;
        }

        /// <summary>
        /// 回收物件
        /// </summary>
        public void Recycle(GameObject go)
        {
            if (_objectToPool.TryGetValue(go, out var pool))
            {
                pool.Release(go);
            }
            else
            {
                Debug.LogWarning("[Pool] Trying to release object not from pool.");
                Destroy(go);
            }
        }
    }
}