using UnityEngine;

namespace Parenting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfigList", menuName = "UI/DownBarButtonConfig List")]
    public class DownBarButtonConfigList : ScriptableObject
    {
        public DownBarButtonConfig[] buttons;
    }
}