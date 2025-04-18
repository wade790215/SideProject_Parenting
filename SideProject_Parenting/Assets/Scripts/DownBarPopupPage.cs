using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting.Scripts
{
    public class DownBarPopupPage : UIPage
    {
        public DownBarPopupPage() : base(UIType.PopUp, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/DownBarPopup";
        }

        protected override void Refresh()
        {
            //TODO 打開時塞入資料?
            Debug.Log($"Data_:{data}");
        }
    }
}