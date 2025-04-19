using System;
using System.Collections.Generic;
using UnityEngine;

namespace Parenting.Scripts.Setting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfig", menuName = "UI/DownBarButtonConfig")]
    public class DownBarButtonConfig : ScriptableObject
    {
        public string label;
        public string[] options;
        public InputFieldData inputFieldData;
        public Sprite icon;
        public List<PopupPageConfig> popupPageConfigs;
        
        public DownBarButtonData ToData()
        {
            return new DownBarButtonData
            {
                label = label,
                iconName = icon != null ? icon.name : "",
                options = options,
                inputFieldData = inputFieldData,
                popupPageConfigs = new List<PopupPageConfig>(popupPageConfigs)
            };
        }
    }
    
    /// <summary>
    /// 因為ScriptablelObject不能直接轉Json，所以用這個來轉
    /// </summary>
    [Serializable]
    public class DownBarButtonData
    {
        public string label;
        public string iconName;
        public string[] options;
        public InputFieldData inputFieldData;
        public List<PopupPageConfig> popupPageConfigs;
    }
    
    [Serializable]
    public class PopupPageConfig
    {
        public string title;
        public PopupInfoItemType itemType;
    }

    [Serializable]
    public class InputFieldData
    {
        public string defaultValue;
        public string unit;
    }

    public enum PopupInfoItemType
    {
        Time,
        Dropdown,
        InputField,
    }
}