using System.Collections.Generic;
using MyPackages.UIFramework.Runtime;
using Parenting.Scripts.Setting;
using UnityEngine;

namespace Parenting.Scripts
{
    public class UIMain : MonoBehaviour
    {
        [SerializeField] private GameObject downBarButtonPrefab;
        [SerializeField] private Transform downBarButtonParent;
        [SerializeField] private DownBarButtonConfigList configList;
        [SerializeField] private DataView dataView;

        private List<DownBarButton> _downBarButtons = new();

        public void Init()
        {
            foreach (var config in configList.buttons)
            {
                var button = Instantiate(downBarButtonPrefab, downBarButtonParent).GetComponent<DownBarButton>();
                button.SetData(config.icon, config.label);
                button.AddListener(() => UIPage.ShowPage<DownBarPopupPage>(config.label));
                _downBarButtons.Add(button);
            }
        }
    }
}