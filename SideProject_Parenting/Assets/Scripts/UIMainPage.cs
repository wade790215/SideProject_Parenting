using System.Collections;
using System.Collections.Generic;
using MyPackages.UIFramework.Runtime;
using UnityEngine;

namespace Parenting
{
    public class UIMainPage : UIPage
    {
        public UIMainPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/UIMain";
        }
    }
}


