using Parenting.Scripts.Utilities;
using UnityEngine;
using UnityEngine.Pool;

namespace Parenting.Scripts
{
    public class MainInfoView : MonoBehaviour
    {
        [SerializeField] private GameObject mainInfoViewPrefab;
        
        private ObjectPool<GameObject> _pool;
        
        private void Start()
        {
            GameObjectPoolManager.Instance.CreatePool(ConstTable.PoolKey.MainInfoView, mainInfoViewPrefab, 5, 20);
        }
    }
}
