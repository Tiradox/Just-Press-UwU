using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool youCanAct = true;

    private MainSettings ms = new MainSettings();
    public string language = "EN";
    public int stage = 0;
    string msPath;
    string TexPath;

    public void Awake()
    {

        msPath = Application.streamingAssetsPath + "/Settings.json";

        if (File.Exists(msPath))
        {
            ms = JsonUtility.FromJson<MainSettings>(File.ReadAllText(msPath));
            LoadSettings();
        }
        else
        {
            Debug.LogError("Ты забыл создать сохранения, идеот!");
        }
    }

    public void LoadSettings()
    {
        language = ms.language;
        stage = ms.stage;
    }

    public void SaveSettings()
    {
        ms.language = language;
        ms.stage = stage;

        File.WriteAllText(msPath, JsonUtility.ToJson(ms));
    }



    //Сохранения
    [Serializable]
    public class MainSettings
    {
        public string language;
        public int stage;

    }
}
