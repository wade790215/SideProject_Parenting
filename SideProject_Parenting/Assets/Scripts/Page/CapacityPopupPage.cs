using System;
using MyPackages.UIFramework.Runtime;
using TMPro;
using UnityEngine;

namespace Parenting.Scripts
{
    public class CapacityPopupPage : UIPage
    {
        private PopupPageView _view;
        public CapacityPopupPage() : base(UIType.PopUp, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/CapacityPopup";
        }

        protected override void Awake(GameObject go)
        {
            _view = go.GetComponent<PopupPageView>();
            _view.GetInputFieldData().ForEach(data =>
            {
                InputFieldManager.Instance.RegisterInputField(data.key, data.inputField);
            });
        }

        protected override void Active()
        {
            base.Active();
            _view.AddCancelListener(() => ClosePage(typeof(CapacityPopupPage).ToString()));
        }

        protected override void Hide()
        {
            base.Hide();
            _view?.RemoveAllListeners();
        }
    }
}