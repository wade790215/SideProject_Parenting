using MyPackages.UIFramework.Runtime;
using Parenting.Scripts.Setting;
using UnityEngine;

namespace Parenting.Scripts
{
    public class DownBarPopupPage : UIPage
    {
        private PopupInfoController _popupInfoController;
        
        public DownBarPopupPage() : base(UIType.PopUp, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/DownBarPopup";
        }

        protected override void Awake(GameObject go)
        {
            base.Awake(go);
            _popupInfoController = go.GetComponent<PopupInfoController>();
            _popupInfoController.Init();
        }

        protected override void Active()
        {
            base.Active();
            _popupInfoController.AddCloseListener(()=>ClosePage(typeof(DownBarPopupPage).ToString()));
        }

        protected override void Hide()
        {
            base.Hide();
            if (_popupInfoController != null)
            {
                _popupInfoController.RemoveAllListeners();
            }
        }
    }
}