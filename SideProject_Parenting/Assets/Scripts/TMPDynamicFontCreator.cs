using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using AtlasPopulationMode = TMPro.AtlasPopulationMode;

public class TMPDynamicFontCreator : MonoBehaviour
{
    [MenuItem("Tools/TMP/建立中文字型 Font Asset (動態)")]
    public static void CreateDynamicFontAsset()
    {
        string fontPath = EditorUtility.OpenFilePanel("選擇中文字型（例如 Noto Sans TC）", Application.dataPath, "ttf");

        if (string.IsNullOrEmpty(fontPath)) return;

        Font font = new Font(fontPath);
        if (font == null)
        {
            Debug.LogError("無法載入字型檔");
            return;
        }

        // 創建 TMP Font Asset
        TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(font, 90, 9, GlyphRenderMode.SDFAA, 1024, 1024, AtlasPopulationMode.Dynamic);

        Material fontMaterial = new Material(Shader.Find("TextMeshPro/Distance Field"));
        fontMaterial.mainTexture = fontAsset.atlasTextures[0];
        fontAsset.material = fontMaterial;

        if (fontAsset == null)
        {
            Debug.LogError("建立 Font Asset 失敗");
            return;
        }

        // 儲存
        string savePath = EditorUtility.SaveFilePanelInProject("儲存 TMP 字型", "TMP_ChineseFont", "asset", "儲存路徑");
        if (!string.IsNullOrEmpty(savePath))
        {
            AssetDatabase.CreateAsset(fontAsset, savePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("✅ 動態 TMP Font Asset 建立成功: " + savePath);
        }
    }
}