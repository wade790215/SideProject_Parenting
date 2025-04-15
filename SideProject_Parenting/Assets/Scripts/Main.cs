using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting.Scripts
{
    public class Main : MonoBehaviour
    {
        private void Awake()
        {
            UIPage.ShowPage<UIMainPage>();
        }
    }
}

