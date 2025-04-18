using MyPackages.UIFramework.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupInfoView : MonoBehaviour
    {
        [SerializeField] private GameObject popupInfoItemPrefab;
        [SerializeField] private ScrollRect popupScrollRect;
        [SerializeField] private Button downBarCloseButton;

        private void Awake()
        {
            downBarCloseButton.onClick.AddListener(UIPage.ClosePage<DownBarPopupPage>);
        }
        
        public void Init()
        {
            //Todo 外部決定要生成幾個跟文字內容          
        }
    }
}