using UnityEngine;

namespace Parenting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfig", menuName = "UI/DownBarButtonConfig")]
    public class DownBarButtonConfig : ScriptableObject
    {
        public string label;

#if ENABLE_ADDRESSABLES
        public string addressableKey;
#else
        public Sprite icon;
#endif
    }
}