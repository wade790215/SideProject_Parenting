using UnityEngine;

namespace Parenting.Scripts.Setting
{
    [CreateAssetMenu(fileName = "PopupInfoItemConfigList", menuName = "UI/PopupInfoItemConfig List")]
    public class PopupInfoItemConfigList : ScriptableObject
    {
        public PopupInfoItemConfig[] buttons;
    }
}