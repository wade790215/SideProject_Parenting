using MyPackages.UIFramework.Runtime;

namespace Parenting.Scripts
{
    public class CapacityPopupPage : UIPage
    {
        public CapacityPopupPage() : base(UIType.PopUp, UIMode.HideOther, UICollider.None)
        {
            uiPath = "Prefab/CapacityPopup";
        }
    }
}