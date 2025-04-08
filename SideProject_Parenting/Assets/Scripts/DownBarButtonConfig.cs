using UnityEngine;

namespace Parenting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfig", menuName = "UI/DownBarButtonConfig")]
    public class DownBarButtonConfig : ScriptableObject
    {
        public string label;
        public Sprite icon;
    }
}