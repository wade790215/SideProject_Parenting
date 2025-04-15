using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupInfoView : MonoBehaviour
    {
        [SerializeField] private GameObject popupInfoItemPrefab;
        [SerializeField] private ScrollRect popupScrollRect;

        public void Init()
        {
            //Todo 外部決定要生成幾個跟文字內容          
        }
    }
}