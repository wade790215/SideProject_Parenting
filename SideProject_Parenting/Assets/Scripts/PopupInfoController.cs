using System;
using System.Linq;
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
        [SerializeField] private DownBarButtonConfigList configList;

        public void AddCloseListener(Action action) => downBarCloseButton.onClick.AddListener(() => action?.Invoke());
        public void RemoveAllListeners() =>downBarCloseButton.onClick.RemoveAllListeners();
        
        public void Init()
        {
            foreach (var config in configList.downBarButtonConfigs)
            {
                var data = config.ToData();
                foreach (var pageConfig in data.popupPageConfigs)
                {
                    var infoItem = Instantiate(popupInfoItemPrefab, popupScrollRect.content).GetComponent<PopupInfoItem>();
                    string displayValue = GetInitialValue(data, pageConfig.itemType);
                    infoItem.SetInfoItemData(pageConfig);
                    infoItem.SetDisplayValue(pageConfig.title, displayValue); 
                }
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