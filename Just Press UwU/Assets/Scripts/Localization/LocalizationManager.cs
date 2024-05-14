using System.IO;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Tiradox.Localization;
using Tiradox.Json;

namespace Tiradox
{
    public static class LocalizationManager
    {
        public static string thisLocalizationCode { get; private set; }

        private static List<JsonString> _strings;
        private static List<LocalizationFont> _fonts;
        private static LocalizationTextData[] _localizationsButtonsDatas;
        private static string _localizationPath;

        public static string[] GetLocalizationsCodes()
        {
            string[] paths = Directory.GetDirectories(Application.streamingAssetsPath + $"\\Localizations");

            for (int i = 0; i < paths.Length; i++)
            {
                paths[i] = paths[i].Replace('/', '\\');
            }

            return paths;
        }

        public static LocalizationTextData[] GetLocalizationsButtonsDatas(string fontIndex)
        {
            if (_localizationsButtonsDatas == null)
            {
                string[] localizationCodes = GetLocalizationsCodes();
                LocalizationTextData[] localizationTextDatas = new LocalizationTextData[localizationCodes.Length];

                for (int i = 0; i < localizationCodes.Length; i++)
                {
                    localizationTextDatas[i].Text = File.ReadAllText($"{localizationCodes[i]}/Name.txt");

                    Debug.Log(Path.GetDirectoryName(localizationCodes[i]));
                    localizationTextDatas[i].Font = GetFont(fontIndex, GetLocalizationFonts(Path.GetDirectoryName(localizationCodes[i]))); 
                }

                _localizationsButtonsDatas = localizationTextDatas;
                return localizationTextDatas;
            }
            else
            {
                return _localizationsButtonsDatas;
            }
        }

        public static void SetLocalization(string localizationCode)
        {
            _localizationPath = Application.streamingAssetsPath + $"/Localizations/{localizationCode}/Localization.json";

            if (File.Exists(_localizationPath))
            {
                _strings = JsonHelper.ReadFromJSON<JsonString>(_localizationPath);
                _fonts = GetLocalizationFonts(localizationCode);
                Debug.Log($"Localization \"{localizationCode}\" successfully loaded");
                thisLocalizationCode = localizationCode;
            }
            else
            {
                Debug.LogError($"Localization for path \"{_localizationPath}\" not found!!!");
                thisLocalizationCode = null;
            }
        }

        private static List<LocalizationFont> GetLocalizationFonts(string localizationCode)
        {
            Debug.Log("Loading localization fonts...");

            string path = Application.streamingAssetsPath + $"/Localizations/{localizationCode}/";
            List<JsonString> fontsNames = JsonHelper.ReadFromJSON<JsonString>(path + "Fonts.json");
            List <LocalizationFont> localizationFonts = new List<LocalizationFont>();

            for(int i = 0; i < fontsNames.Count; i++)
            {
                localizationFonts.Add(new LocalizationFont());
                localizationFonts[i].ID = fontsNames[i].ID;

                TMP_FontAssetData fontData = null;
                string fontPath = $"{path}Fonts/{fontsNames[i].Value}";
                if (File.Exists(fontPath + ".json"))
                {
                    fontData = JsonUtility.FromJson<TMP_FontAssetData>(File.ReadAllText(fontPath + ".json"));
                }

                localizationFonts[i].Value = TMP_FontAssetImporter.GetByPath(fontPath + ".ttf", fontData);

                Debug.Log($"Font \"{fontsNames[i].Value}\" loaded successfully");
            }

            return localizationFonts;
        }

        public static string GetText(string index)
        {
            JsonString str = _strings.Find(s => s.ID == index);

            if (str != null)
            {
                return str.Value;
            }
            else
            {
                Debug.Log($"String with index \"{index}\" does not exist");
                return "error";
            }
        }

        public static TMP_FontAsset GetFont(string index)
        {
            LocalizationFont str = _fonts.Find(s => s.ID == index);

            if (str != null)
            {
                return str.Value;
            }
            else
            {
                Debug.Log($"Font with index \"{index}\" does not exist in \"{thisLocalizationCode}\" localization");
                return null;
            }
        }
        public static TMP_FontAsset GetFont(string index, List<LocalizationFont> fonts = null)
        {
            if(fonts == null)
            {
                fonts = _fonts;
            }

            LocalizationFont str = fonts.Find(s => s.ID == index);

            if (str != null)
            {
                return str.Value;
            }
            else
            {
                if(fonts != _fonts)
                {
                    Debug.Log($"Font with index \"{index}\" does not find");
                }
                else
                {
                    Debug.Log($"Font with index \"{index}\" does not exist in \"{thisLocalizationCode}\" localization");
                }
                return null;
            }
        }
    }
}