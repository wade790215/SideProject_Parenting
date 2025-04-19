using System;
using Parenting.Scripts.Setting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class PopupInfoItem : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _btnTxt;
        [SerializeField] private TextMeshProUGUI _title;

        private Action _onClickEvent;

        public void AddListener(Action action)
        {
            _onClickEvent += action;
        }

        public void RemoveListener(Action action)
        {
            _onClickEvent -= action;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(() => _onClickEvent?.Invoke());
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
    }
}