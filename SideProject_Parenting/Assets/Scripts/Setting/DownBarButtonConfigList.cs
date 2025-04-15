using UnityEngine;

namespace Parenting.Scripts.Setting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfigList", menuName = "UI/DownBarButtonConfig List")]
    public class DownBarButtonConfigList : ScriptableObject
    {
        public DownBarButtonConfig[] buttons;
    }
}