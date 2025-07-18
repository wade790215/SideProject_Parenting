using System;
using Parenting.Scripts.Setting;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting.Scripts
{
    public class DownBarButton : MonoBehaviour
    {
        [SerializeField] private Image btnIcon;
        [SerializeField] private Text btnTxt;
        private Action _onClickEvent;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

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
    
        public void SetData(Sprite icon, string text)
        {
            btnIcon.sprite = icon;
            btnTxt.text = text;
        }
    }
}
