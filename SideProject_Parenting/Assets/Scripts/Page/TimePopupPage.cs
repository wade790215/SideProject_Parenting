using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting.Scripts
{
    public class TimePopupPage : UIPage
    {
        private PopupPageView _view;
        public TimePopupPage() : base(UIType.PopUp, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/TimePopup";
        }
        
        protected override void Awake(GameObject go)
        {
            _view = go.GetComponent<PopupPageView>();
        }
        
        protected override void Active()
        {
            base.Active();
            _view.AddCancelListener(() => ClosePage(typeof(TimePopupPage).ToString()));
        }
        
        protected override void Hide()
        {
            base.Hide();
            _view?.RemoveAllListeners();
        }
    }
}