using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupPageView : MonoBehaviour
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button cancelButton;
        [SerializeField] private List<InputFieldData> inputFieldTMP;
        
        public void AddSaveListener(Action action) => saveButton.onClick.AddListener(() => action?.Invoke());
        public void RemoveSaveListener(Action action) => saveButton.onClick.RemoveListener(() => action?.Invoke());

        public void AddCancelListener(Action action) => cancelButton.onClick.AddListener(() => action?.Invoke());
        public void RemoveCancelListener(Action action) => cancelButton.onClick.RemoveListener(() => action?.Invoke());
        
        public void RemoveAllListeners()
        {
            saveButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
        }
        
        public Dictionary<string, string> GetInputFieldValues()
        {
            var inputFieldValues = new Dictionary<string, string>();
            foreach (var inputFieldData in inputFieldTMP)
            {
                if (inputFieldData.inputField != null)
                {
                    inputFieldValues[inputFieldData.key] = inputFieldData.inputField.text;
                }
            }
            return inputFieldValues;
        }
    }
    
    [Serializable]
    public class InputFieldData
    {
        public string key;
        public TMP_InputField inputField;
    }
}