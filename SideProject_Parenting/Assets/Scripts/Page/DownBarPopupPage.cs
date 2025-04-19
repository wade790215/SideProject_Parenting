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
            
        }

        protected override void Refresh()
        {
            if (data != null)
            {
                var result = JsonUtility.FromJson<DownBarButtonData>(data.ToString());
                if (result != null)
                {
                    _popupInfoController.Init(result);
                }
            }
        }
    }
}