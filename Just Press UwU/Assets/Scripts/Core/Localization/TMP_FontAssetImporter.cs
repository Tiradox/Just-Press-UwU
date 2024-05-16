using System;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using TMPro;

namespace Tiradox.Localization
{
    public static class TMP_FontAssetImporter
    {
        public static TMP_FontAsset GetByPath(string path, TMP_FontAssetData fontAssetData = null)
        {
            Font font = new Font(path);
            if (fontAssetData == null)
            {
                fontAssetData = new TMP_FontAssetData();
            }
            TMP_FontAsset fontAsset = TMP_FontAsset.CreateFontAsset(font, fontAssetData.SamplingPointSize, fontAssetData.AtlasPadding, (GlyphRenderMode)fontAssetData.RenderMode, fontAssetData.AtlasWidth, fontAssetData.AtlasHeight);
            return fontAsset;
        }
    }

    [Serializable]
    public class TMP_FontAssetData
    {
        public int SamplingPointSize = 112;
        public int AtlasPadding = 5;
        public int AtlasWidth = 1024;
        public int AtlasHeight = 1024;
        public int RenderMode = (int)GlyphRenderMode.SDFAA;
    }
}
