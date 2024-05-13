using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class RebutButton : MonoBehaviour
{
    public Sprite[] B = new Sprite[2];
    public int[,] whb = new int[5,1];
    public GameObject[] sp = new GameObject[5];
    public GameManager GM;
    public DialogueSystem DS;
    private bool b = true;
    public Animator RADAnim;
    public GameObject PaperG;
    public Animator CamAnim;

    [Space]
    public AudioSource MM;
    public AudioSource A1;
    public AudioSource A2;
    public AudioSource A3;
    public AudioSource A4;
    public AudioSource D1;
    public AudioSource D2;

    [Space]
    public string path;

    [Space]
    public Text DelTex;
    public PlayableDirector Cat2;
    protected string Priy = "Отче наш, Иже еси на небесех! Да святится имя Твое, да приидет Царствие Твое, да будет воля Твоя, яко на небеси и на земли. Хлеб наш насущный даждь нам днесь; и остави нам долги наша, якоже и мы оставляем должникам нашим; и не введи нас во искушение, но избави нас от лукавого, яко Твое есть Царствие и сила, и слава во веки веков.";

    [Space]
    public TypewriterScript TS;

    public void Start()
    {
        path = Application.streamingAssetsPath + "/_Text/" + GM.language + "/Dialogues/Lm/List1.txt";
    }
    public void MiniButton(int i)
    {
        if (whb[i, 0] == 1) whb[i, 0] = 0;
        else whb[i, 0] = 1;
        sp[i].GetComponent<Image>().sprite = B[whb[i, 0]]; 
        A1.Play();
    }

    public void OnMouseDown()
    {
        if(GM.youCanAct && b)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Open");
            A2.Play(); b = false;
        }            
    }

    public void RADButton()
    {
        RADAnim.SetTrigger("Down");
        A3.Play();

        if (whb[0, 0] == 0 && whb[1, 0] == 1 && whb[2, 0] == 1 && whb[3, 0] == 0 && whb[4, 0] == 1 && GM.youCanAct)
        {
            GM.youCanAct = false;
            StartCoroutine(Deli());
        }
    }

    IEnumerator Deli()
    {
        Cat2.Play();
        yield return new WaitForSeconds(2.5f);
        DelTex.text += "Console initialization...\n";
        MM.mute = true;
        this.gameObject.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(2f);
        DelTex.text += "Bruh_mod: on\n";
        yield return new WaitForSeconds(2f);
        DelTex.text += "Launching - Reboot_Algorithm\n";
        yield return new WaitForSeconds(1f);
        DelTex.text += "Starting file check...\n";
        yield return new WaitForSeconds(1.6f + 0.5f);
        for (int i = 0; i != 101; i++)
        {
            DelTex.text += "Checking files...   " + i + "%\n";
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.2f);
        DelTex.text += "[ successfully ]\n";
        yield return new WaitForSeconds(0.1f);
        DelTex.text += "[ root file corruption detected ]\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "Running: RCR (Repository_Check_Root) v3.0567\n";
        yield return new WaitForSeconds(1f);
        for (int i = 0; i != 101; i++)
        {
            DelTex.text += "Checking root files ...   " + i + "%\n";
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "[ unregistered software foundе ]\n";
        yield return new WaitForSeconds(0.2f);
        DelTex.text += "Object analysis...\n [";
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i != 35; i++)
        {
            DelTex.text += "File_" + i + " -   [";
            for (int i2 = 0; i2 != 8; i2++)
            {
                DelTex.text += "/";
                yield return new WaitForSeconds(0.01f);
            }
            DelTex.text += "]\n";
        }
        DelTex.text += "\n[ object detected ]";
        yield return new WaitForSeconds(1f);
        DelTex.text += "Object name: GYFERIUS.rar\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "Trying to fix...\n";
        DelTex.text += "Generating attack keys...\n";
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i != 151; i++)
        {
            DelTex.text += "Key           -   " + i + "   -   " + UnityEngine.Random.Range(0, 9) + "   -          " + UnityEngine.Random.Range(10000, 99999) + " F\n";
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.3f);
        DelTex.text = "";
        DelTex.text += "Keys created successfully\n";
        yield return new WaitForSeconds(0.4f);
        DelTex.text += "Initialization: Attack\n";
        yield return new WaitForSeconds(0.3f);
        for (int i2 = 0; i2 != 4; i2++)
        {
            DelTex.text += "\n           Phase - " + i2 + "\n";
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i != 100; i++)
            {
                int ii = UnityEngine.Random.Range(0, 3);
                if (ii == 0) DelTex.text += "Attack N" + i + "       |       Status: Success\n";
                else DelTex.text += "Attack N" + i + "       |       Status: Failure\n";
                yield return new WaitForSeconds(0.01f);
            }
        }
        DelTex.text = "";
        yield return new WaitForSeconds(0.02f);
        DelTex.text += "[    fail    ]\n";
        yield return new WaitForSeconds(0.02f);
        DelTex.text += "\nAnalysis of the situation...\n";
        yield return new WaitForSeconds(0.02f);
        DelTex.text += "[";
        for (int i2 = 0; i2 != 14; i2++)
        {
            DelTex.text += "#";
            yield return new WaitForSeconds(0.1f);
        }
        DelTex.text += "]\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "Object damage: negligible\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "Access rights R: none\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "Resources: running out\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "Situation: shit\n";
        yield return new WaitForSeconds(1f);
        DelTex.text += "Sending a request to the server for access rights R...\n";
        yield return new WaitForSeconds(0.02f);
        DelTex.text += "[";
        for (int i2 = 0; i2 != 14; i2++)
        {
            DelTex.text += "#";
            yield return new WaitForSeconds(0.1f);
        }
        DelTex.text += "]\n";
        yield return new WaitForSeconds(0.02f);
        DelTex.text += "[ ACCESS DENIED ]\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "...\n\n";
        yield return new WaitForSeconds(0.5f);
        DelTex.text += "File Opening    -    Prayers.txt\n\n> ";
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i != Priy.Length; i++)
        {
            DelTex.text += Priy[i];
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.2f);
        DelTex.text += "\nАминь";

    }

    public void EndDel()
    {
        GM.youCanAct = true;
        TS.UpT();
    }

    public void Paper()
    {
        if (GM.youCanAct)
        {
            DS.ListOfPaperSet(PaperG, File.ReadAllText(path));
            A4.Play();
        }
    }
}
