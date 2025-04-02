using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownBarButton : MonoBehaviour
{
    public Action OnClickEvent;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void AddListener(Action action)
    {
        OnClickEvent += action;
    }

    public void RemoveListener(Action action)
    {
        OnClickEvent -= action;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() => OnClickEvent?.Invoke());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}