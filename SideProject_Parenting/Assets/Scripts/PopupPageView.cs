using System;
using System.Collections.Generic;
using Parenting.Scripts.Utilities;
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
        
        public List<InputFieldData> GetInputFieldData()
        {
            List<InputFieldData> inputFieldDataList = new();
            foreach (var inputField in inputFieldTMP)
            {
                InputFieldData data = new()
                {
                    key = inputField.key,
                    inputField = inputField.inputField
                };
                inputFieldDataList.Add(data);
            }
            return inputFieldDataList;
        }
    }
    
    [Serializable]
    public class InputFieldData
    {
        public EnumTable.InputFieldKey key;
        public TMP_InputField inputField;
    }
}