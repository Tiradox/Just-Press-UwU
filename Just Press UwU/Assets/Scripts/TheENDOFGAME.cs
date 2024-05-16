using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheENDOFGAME : MonoBehaviour
{
    public Sprite sRu;
    public Sprite sEn;
    public SpriteRenderer sr;

    private void Start()
    {
        SettingsSaveManager.settingsSave.GameStage = 99;

        if (SettingsSaveManager.settingsSave.LanguageCode == "RUS")
        {
            sr.sprite = sRu;
        }
        else if (SettingsSaveManager.settingsSave.LanguageCode == "ENG")
        {
            sr.sprite = sEn;
        }
    }
}
