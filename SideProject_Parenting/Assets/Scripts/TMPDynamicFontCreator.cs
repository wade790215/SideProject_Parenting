using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace Parenting
{
    public class TMPChineseFontCreator : MonoBehaviour
    {
        [MenuItem("Tools/TMP/建立中文字 TMP FontAsset")]
        public static void CreateTMPChineseFontAsset()
        {
            string fontPath = EditorUtility.OpenFilePanel("選擇中文字型（.ttf）", Application.dataPath, "ttf");
            if (string.IsNullOrEmpty(fontPath)) return;

            Font systemFont = new Font(fontPath);
            if (systemFont == null)
            {
                Debug.LogError("無法載入字型檔案");
                return;
            }

            TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(
                systemFont,
                90,
                9,
                GlyphRenderMode.SDFAA,
                1024,
                1024,
                AtlasPopulationMode.Static
            );

            if (fontAsset == null)
            {
                Debug.LogError("建立 Font Asset 失敗");
                return;
            }

            string savePath = EditorUtility.SaveFilePanelInProject("儲存 TMP 字型資源", "TMP_ChineseFont", "asset", "選擇儲存位置");
            if (string.IsNullOrEmpty(savePath)) return;

            AssetDatabase.CreateAsset(fontAsset, savePath);

            if (fontAsset.material != null)
                AssetDatabase.AddObjectToAsset(fontAsset.material, fontAsset);

            if (fontAsset.atlasTexture != null)
                AssetDatabase.AddObjectToAsset(fontAsset.atlasTexture, fontAsset);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"✅ 字型建立成功：{savePath}");
        }
    }
}