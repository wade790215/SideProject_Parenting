using MyPackages.UIFramework.Runtime;

namespace Parenting.Scripts
{
    public class TimePopupPage : UIPage
    {
        public TimePopupPage() : base(UIType.PopUp, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/TimePopup";
        }
    }
}