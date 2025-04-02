using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            UIPage.ShowPage<UIMainPage>();
        }
    }
}

