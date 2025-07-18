using System;
using System.Collections.Generic;
using System.Linq;
using MyPackages.UIFramework.Runtime;
using Parenting.Scripts.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupInfoController : MonoBehaviour
    {
        [SerializeField] private GameObject popupInfoItemPrefab;
        [SerializeField] private ScrollRect popupScrollRect;
        [SerializeField] private Button downBarCloseButton;

        public void AddCloseListener(Action action) => downBarCloseButton.onClick.AddListener(() => action?.Invoke());
        public void RemoveAllListeners()
        {
            downBarCloseButton.onClick.RemoveAllListeners();
        }
        
        public void Init(DownBarButtonData data)
        {
            foreach (var config in data.popupPageConfigs)
            {
                var infoItem = Instantiate(popupInfoItemPrefab, popupScrollRect.content).GetComponent<PopupInfoItem>();
                string displayValue = GetInitialValue(data, config.itemType);
                infoItem.SetInfoItemData(config);
                infoItem.SetDisplayValue(config.title, displayValue);
            }
        }

        private string GetInitialValue(DownBarButtonData data, PopupInfoItemType itemType)
        {
            return itemType switch
            {
                PopupInfoItemType.Time => DateTime.Now.ToString("HH:mm"),
                PopupInfoItemType.InputField => $"{data.inputFieldData.defaultValue}{data.inputFieldData.unit}",
                PopupInfoItemType.Dropdown => data.options?.FirstOrDefault() ?? "請選擇",
                _ => ""
            };
        }
    }
}