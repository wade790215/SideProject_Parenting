using System;
using MyPackages.UIFramework.Runtime;
using Parenting.Scripts.Setting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupInfoItem : MonoBehaviour
    {
        [SerializeField] private PopupInfoItemType _itemType;
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _btnTxt;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private GameObject _dropdown;

        private Action _onClickEvent;

        public void AddListener(Action action) => _onClickEvent += action;
        public void RemoveListener(Action action) => _onClickEvent -= action;

        private void OnEnable()
        {
            _button.onClick.AddListener(() => _onClickEvent?.Invoke());
            _button.onClick.AddListener(ToggleActiveByType);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void SetDisplayValue(string title, string value)
        {
            _title.text = title;
            _btnTxt.text = value;
        }

        public void SetInfoItemData(PopupPageConfig config)
        {
            _itemType = config.itemType;
        }

        private void ToggleActiveByType()
        {
            switch (_itemType)
            {
                case PopupInfoItemType.Time:
                    UIPage.ShowPage<TimePopupPage>();
                    break;
                case PopupInfoItemType.InputField:
                    UIPage.ShowPage<CapacityPopupPage>();
                    break;
                case PopupInfoItemType.Dropdown:
                    _dropdown.SetActive(!_dropdown.activeSelf);
                    break;
            }
        }
    }
}