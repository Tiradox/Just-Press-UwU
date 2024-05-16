using System;
using System.IO;
using UnityEngine;
using Tiradox;

public class SettingsSaveManager : MonoBehaviour
{
    public static SettingsSave settingsSave { get; private set; }
    private string _savesPath;

    private void Awake()
    {
        if(settingsSave != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        _savesPath = Application.streamingAssetsPath + "/Saves/Settings.json";

        if (File.Exists(_savesPath))
        {
            settingsSave = JsonUtility.FromJson<SettingsSave>(File.ReadAllText(_savesPath));
        }
        else
        {
            settingsSave = new SettingsSave();
        }

        if(settingsSave.LanguageCode != null)
        {
            LocalizationManager.SetLocalization(settingsSave.LanguageCode);
        }
    }

    private void OnApplicationQuit()
    {
        File.WriteAllText(_savesPath, JsonUtility.ToJson(settingsSave));
    }
}

//Сохранения
[Serializable]
public class SettingsSave
{
    public string LanguageCode = null;
    public int GameStage = 0;
}