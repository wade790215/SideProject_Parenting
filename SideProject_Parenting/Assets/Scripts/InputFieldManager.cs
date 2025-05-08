using System;
using System.Collections.Generic;
using Parenting.Scripts.Utilities;
using TMPro;
using UnityEngine;

namespace Parenting.Scripts
{
    public class InputFieldManager : MonoBehaviour
    {
        public static InputFieldManager Instance { get; private set; }
        private Dictionary<EnumTable.InputFieldKey, TMP_InputField> _inputFieldDict;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            _inputFieldDict = new Dictionary<EnumTable.InputFieldKey, TMP_InputField>();
        }
        
        public void RegisterInputField(EnumTable.InputFieldKey key, TMP_InputField inputField)
        {
            if (!_inputFieldDict.ContainsKey(key))
            {
                _inputFieldDict.Add(key, inputField);
            }
            else
            {
                Debug.LogWarning($"Duplicate InputFieldKey: {key}");
            }
        }
        
        public void UnregisterInputField(EnumTable.InputFieldKey key)
        {
            if (_inputFieldDict.ContainsKey(key))
            {
                _inputFieldDict.Remove(key);
            }
            else
            {
                Debug.LogWarning($"InputFieldKey {key} not found for unregistration.");
            }
        }
        
        public void ClearInputFields()
        {
            foreach (var inputField in _inputFieldDict.Values)
            {
                inputField.text = string.Empty;
            }
        }

        private TMP_InputField GetInputField(EnumTable.InputFieldKey key)
        {
            if (_inputFieldDict.TryGetValue(key, out var inputField))
            {
                return inputField;
            }

            Debug.LogError($"InputField with key {key} not found.");
            return null;
        }

        public string GetInputText(EnumTable.InputFieldKey key)
        {
            var inputField = GetInputField(key);
            return inputField != null ? inputField.text : string.Empty;
        }

        public void SetInputText(EnumTable.InputFieldKey key, string text)
        {
            var inputField = GetInputField(key);
            if (inputField != null)
            {
                inputField.text = text;
            }
        }
    }
}
