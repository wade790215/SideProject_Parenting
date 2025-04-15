using UnityEngine;

namespace Parenting.Scripts.Setting
{
    [CreateAssetMenu(fileName = "DownBarButtonConfig", menuName = "UI/DownBarButtonConfig")]
    public class DownBarButtonConfig : ScriptableObject
    {
        public string label;
        public Sprite icon;
    }
}