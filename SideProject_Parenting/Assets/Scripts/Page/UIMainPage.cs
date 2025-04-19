using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting.Scripts
{
    public class UIMainPage : UIPage
    {
        public UIMainPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/UIMain";
        }

        protected override void Awake(GameObject go)
        {
            UIMain uiMain = go.GetComponent<UIMain>();
            if (uiMain != null)
            {
                uiMain.Init();
            }
        }
    }
}


