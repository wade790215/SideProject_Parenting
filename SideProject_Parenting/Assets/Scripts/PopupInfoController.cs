using System;
using System.Collections.Generic;
using System.Linq;
using Parenting.Scripts.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupInfoController : MonoBehaviour
    {
        [SerializeField] private PopupInfoItem popupInfoItemPrefab;
        [SerializeField] private ScrollRect popupScrollRect;
        [SerializeField] private Button downBarCloseButton;
        [SerializeField] private DownBarButtonConfigList configList;
        
        private Pool<PopupInfoItem> _itemPool;
        private readonly List<PopupInfoItem> _activeItems = new();
        private List<DownBarButtonData> _datas;
        
        public void AddCloseListener(Action action) => downBarCloseButton.onClick.AddListener(() => action?.Invoke());
        public void RemoveAllListeners() =>downBarCloseButton.onClick.RemoveAllListeners();
        
        private void Awake()
        {
            // 預估一個上限數量，避免第一次開啟卡頓
            int estimate = configList?.downBarButtonConfigs?.Sum(c => c.ToData().popupPageConfigs.Count) ?? 10;
            _itemPool = new Pool<PopupInfoItem>(popupInfoItemPrefab, popupScrollRect.content, prewarmCount: Mathf.Max(estimate, 10));
        }
        
        public void Init()
        {
            _datas = configList.downBarButtonConfigs
                .Select(c => c.ToData())
                .ToList();
            
            foreach (var config in configList.downBarButtonConfigs)
            {
                var data = config.ToData();
                foreach (var pageConfig in data.popupPageConfigs)
                {
                    //TODO 改成只生成popupInfoItem的Prefab 當點擊打開時再把資料寫入
                    var infoItem = Instantiate(popupInfoItemPrefab, popupScrollRect.content).GetComponent<PopupInfoItem>();
                  
                }
            }
        }

        public void OpenAndBind(int dataIndex)
        {
            CloseAndRecycle(); // 確保乾淨狀態

            if (_datas == null || dataIndex < 0 || dataIndex >= _datas.Count)
                return;

            var data = _datas[dataIndex];

            foreach (var pageConfig in data.popupPageConfigs)
            {
                var infoItem = _itemPool.Get();
                infoItem.transform.SetParent(popupScrollRect.content, false);

                // 設定資料
                infoItem.SetInfoItemData(pageConfig);
                string displayValue = GetInitialValue(data, pageConfig.itemType);
                infoItem.SetDisplayValue(pageConfig.title, displayValue);
                infoItem.ActiveUIByType();

                _activeItems.Add(infoItem);
            }

            // 重新建置 Layout，避免高度不正確
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(popupScrollRect.content);
        }
        
        public void CloseAndRecycle()
        {
            for (int i = 0; i < _activeItems.Count; i++)
            {
                // 若 PopupInfoItem 有 Reset/Unbind 之類方法，先調用清掉事件與暫存
                _activeItems[i].ResetView(); // 建議你在 PopupInfoItem 實作
                _itemPool.Release(_activeItems[i]);
            }
            _activeItems.Clear();

            // 如有需要，清除關閉按鈕的所有監聽
            // RemoveAllListeners();
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