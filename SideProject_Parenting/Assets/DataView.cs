using System;
using TMPro;
using UnityEngine;

public class DataView : MonoBehaviour
{
    [SerializeField] private TMP_Text dateText;

    private static readonly string[] Weekdays =
    {
        "週日", "週一", "週二", "週三", "週四", "週五", "週六"
    };
    
    private void Start()
    {
        dateText.text = FormatDate(DateTime.Now);
    }
    
    public void SetDate(DateTime date)
    {
        dateText.text = FormatDate(date);
    }

    private string FormatDate(DateTime date)
    {
        string weekday = Weekdays[(int)date.DayOfWeek];
        return $"{weekday}, {date.Month}月 {date.Day}日";
    }
}
