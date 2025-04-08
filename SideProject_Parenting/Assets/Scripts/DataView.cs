using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting
{
    public class DataView : MonoBehaviour
    {
        [SerializeField] private TMP_Text dateText;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
    
        private Action _onLeftButtonClick;
        private Action _onRightButtonClick;
        private DateTime _currentDate;

        private static readonly string[] Weekdays =
        {
            "週日", "週一", "週二", "週三", "週四", "週五", "週六"
        };
    
        private void Start()
        {
            _currentDate = DateTime.Now;
            UpdateDateText();
        }
    
        private void OnEnable()
        {
            leftButton.onClick.AddListener(() =>
            {
                _onLeftButtonClick?.Invoke();
                OnClickLeft();
            });
            rightButton.onClick.AddListener(() =>
            {
                _onRightButtonClick?.Invoke();
                OnClickRight();
            });
        }
    
        private void OnDisable()
        {
            leftButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
        }
    
        public void SetLeftButtonListener(Action action)
        {
            _onLeftButtonClick = action;
        }

        public void SetRightButtonListener(Action action)
        {
            _onRightButtonClick = action;
        }
    
        public void SetDate(DateTime date)
        {
            _currentDate = date;
            UpdateDateText();
        }
        
        private void UpdateDateText()
        {
            dateText.text = FormatDate(_currentDate);
        }
        
        private void OnClickLeft()
        {
            _currentDate = _currentDate.AddDays(-1);
            UpdateDateText();
        }

        private void OnClickRight()
        {
            _currentDate = _currentDate.AddDays(1);
            UpdateDateText();
        }

        private string FormatDate(DateTime date)
        {
            string weekday = Weekdays[(int)date.DayOfWeek];
            return $"{weekday}, {date.Month}月 {date.Day}日";
        }
    }
}
