using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Parenting
{
    public class MainInfoItem: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        [SerializeField] private TextMeshProUGUI content;
        [SerializeField] private TextMeshProUGUI recordTime;
        [SerializeField] private Image icon;

        public void SetData(Sprite icon,string recordTime , string titleText, string contentText)
        {
            title.text = titleText;
            content.text = contentText;
            this.recordTime.text = recordTime;
            this.icon.sprite = icon;
        }
    }
}