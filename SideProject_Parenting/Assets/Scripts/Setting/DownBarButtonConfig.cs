using System;
using System.Collections.Generic;
using UnityEngine;

namespace Parenting.Scripts.Setting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfig", menuName = "UI/DownBarButtonConfig")]
    public class DownBarButtonConfig : ScriptableObject
    {
        public string label;
        public Sprite icon;
        public List<PopupPageConfig> popupPageConfigs;
        //TODO 需要Dropdown的內容會不一樣
        //TODO 需要InputField的單位不一樣
        //TODO 時間大家都依樣
    }
    
    [Serializable]
    public class PopupPageConfig
    {
        public string title;
        public PopupInfoItemType itemType;
    }

    public enum PopupInfoItemType
    {
        Time,
        Dropdown,
        InputField,
    }
}