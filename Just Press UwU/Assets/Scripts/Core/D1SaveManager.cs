using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class D1SaveManager : MonoBehaviour
{
    [HideInInspector]
    public bool itFell = false;
    [HideInInspector]
    public bool dorHasOpen = false;
    [HideInInspector]
    public int spavnPlase = 0;
    [HideInInspector]
    public string spavnPlaseName = "";
    [HideInInspector]
    public bool[] triggerDialoge = new bool[6];
    [HideInInspector]
    public bool[] MusicMans = new bool[7];
    [HideInInspector]
    public int MusicMansInt = 0;
    [HideInInspector]
    public bool ParcurIsEnd;
    [HideInInspector]
    public bool PunsIsRep;
    [HideInInspector]
    public bool RepIsUp;
    [HideInInspector]
    public bool[] сhatDialogs = new bool[20];
    [HideInInspector]
    public bool TheColAct;

    private D1Saves ds = new D1Saves();
    string msPath;

    void Awake()
    {
        msPath = Application.streamingAssetsPath + "/D1Saves.json";

        if (File.Exists(msPath))
        {
            ds = JsonUtility.FromJson<D1Saves>(File.ReadAllText(msPath));
        }
        else
        {
            File.WriteAllText(msPath, JsonUtility.ToJson(ds));
        }
        LoadSettings();
    }

    public void LoadSettings()
    {
        itFell = ds.itFell;
        dorHasOpen = ds.dorHasOpen;
        spavnPlase = ds.spavnPlase;
        triggerDialoge = ds.triggerDialoge;
        spavnPlaseName = ds.spavnPlaseName;
        MusicMans = ds.MusicMans;
        MusicMansInt = ds.MusicMansInt;
        ParcurIsEnd = ds.ParcurIsEnd;
        PunsIsRep = ds.PunsIsRep;
        RepIsUp = ds.RepIsUp;
        сhatDialogs = ds.сhatDialogs;
        TheColAct = ds.TheColAct;
    }

    public void SaveSettings()
    {
        ds.itFell = itFell;
        ds.dorHasOpen = dorHasOpen;
        ds.spavnPlase = spavnPlase;
        ds.triggerDialoge = triggerDialoge;
        ds.spavnPlaseName = spavnPlaseName;
        ds.MusicMans = MusicMans;
        ds.MusicMansInt = MusicMansInt;
        ds.ParcurIsEnd = ParcurIsEnd;
        ds.PunsIsRep = PunsIsRep;
        ds.RepIsUp = RepIsUp;
        ds.сhatDialogs = сhatDialogs;
        ds.TheColAct = TheColAct;

        File.WriteAllText(msPath, JsonUtility.ToJson(ds));
    }

    [Serializable]
    public class D1Saves
    {
        public bool itFell;
        public bool dorHasOpen;
        public int spavnPlase;
        public bool[] triggerDialoge = new bool[5];
        public string spavnPlaseName;
        public bool[] MusicMans = new bool[8];
        public int MusicMansInt;
        public bool ParcurIsEnd;
        public bool PunsIsRep;
        public bool RepIsUp;
        public bool[] сhatDialogs = new bool[20];
        public bool TheColAct;
    }
}
