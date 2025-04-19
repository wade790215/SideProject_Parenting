using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting.Scripts
{
    public class Main : MonoBehaviour
    {
        private void Awake()
        {
            InitPage();
        }

        private void InitPage()
        {
            UIPage.ShowPage<UIMainPage>();
            UIPage.ShowPage<DownBarPopupPage>();
            UIPage.ClosePage<DownBarPopupPage>();
        }
    }
}

