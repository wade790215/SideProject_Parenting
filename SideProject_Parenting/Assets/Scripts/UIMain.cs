using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parenting
{
    public class UIMain : MonoBehaviour
    {
        [SerializeField] private GameObject downBarButtonPrefab;
        [SerializeField] private Transform downBarButtonParent;
        [SerializeField] private DownBarButtonConfigList configList;

        private List<DownBarButton> _downBarButtons = new();

        public void Init()
        {
            foreach (var config in configList.buttons)
            {
                var button = Instantiate(downBarButtonPrefab, downBarButtonParent).GetComponent<DownBarButton>();

#if ENABLE_ADDRESSABLES
                button.SetData(config.addressableKey, config.label);
#else
                button.SetData(config.icon, config.label);
#endif
                button.AddListener(() => Debug.Log($"點擊：{config.label}"));
                _downBarButtons.Add(button);
            }
        }
    }
}