using UnityEngine;

namespace Parenting.Scripts.Setting
{
    [CreateAssetMenu(fileName = "PopupInfoItemConfig", menuName = "UI/PopupInfoItemConfig")]
    public class PopupInfoItemConfig : ScriptableObject
    {
        public string title;
        public string btnText;
    }
}