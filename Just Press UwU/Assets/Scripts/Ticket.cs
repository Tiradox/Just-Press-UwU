using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    public bool Yas;
    public AudioSource tearingОff;
    public Vector3 offSet;
    public AudioSource A4;
    public bool Read;
    public Animation TTZAnim;

    [Space]
    public string path;
    public DialogueSystem DS;
    public GameObject PaperG;

    public bool firstTime = true;

    public void Start()
    {
        path = Application.streamingAssetsPath + "/_Text/" + SettingsSaveManager.settingsSave.LanguageCode + "/Dialogues/Lm/List2.txt";
    }
    public void SetPos()
    {
        if (GameManager.uCan && Yas)
        {
            Vector3 def = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.localPosition = def - offSet;
        }
    }

    public void Click()
    {
        if (firstTime && GameManager.uCan && Yas)
        {
            tearingОff.Play();
            firstTime = false;
            TTZAnim.Play("Left");
        }
        if (GameManager.uCan && Yas)
        {
            TTZAnim.Play("Left");
        }
    }

    public void Donw()
    {
        if (Read)
        {
            this.transform.localPosition = new Vector2(-5.4063f, 1.224f);
            DS.ListOfPaperSet(PaperG, File.ReadAllText(path));
            //01000111 01101001 01100110 01100101 01110010 01101001 01110101 01110011 00101100 00100000 01000111 01101001 01100110 01101011 01110010 01101001 01110101 01110011 00101100 00100000 01000111 01101001 01100110 01100101 01110010 01101001 01110101 01110011 00100000 00101110 00101110 00101110 00100000 01001000 01100101 00100000 01101010 01110101 01110011 01110100 00100000 01110111 01100001 01101110 01110100 01110011 00100000 01100001 00100000 01110000 01101001 01100101 01100011 01100101 00100000 01101111 01100110 00100000 01101000 01101001 01101101 01110011 01100101 01101100 01100110 00100000 01100010 01100001 01100011 01101011 00101110 00100000
            A4.Play();
        }
        else if (GameManager.uCan && Yas)
        {
            TTZAnim.Play("Right");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TicketsTrigZone")
        {
            Read = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TicketsTrigZone")
        {
            Read = false;
        }
    }
}
