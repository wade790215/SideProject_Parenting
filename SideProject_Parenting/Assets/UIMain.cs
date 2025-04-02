using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIMain : MonoBehaviour
{
    [SerializeField] private GameObject downBarButtonPrefab;
    [SerializeField] private Transform downBarButtonParent;
    
    private List<DownBarButton> _downBarButtons = new ();

    public void Init()
    {
        for (int i = 0; i < 7; i++)
        {
             var downBarButton = Instantiate(downBarButtonPrefab,downBarButtonParent).GetComponent<DownBarButton>();
             var index = i;
             downBarButton.AddListener(() =>
             {
                 Debug.Log($"Button {index} clicked");
             });    
             _downBarButtons.Add(downBarButton);
        }
    }
}
