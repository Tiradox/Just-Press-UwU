using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket2 : MonoBehaviour
{
    public GameManager GM;
    public bool Yas;
    public Vector3 offSet;
    public AudioSource A4;
    public bool Read;
    public Animation TTZAnim;

    [Space]
    public DialogueSystem DS;
    public GameObject PaperG;

    private bool firstTime = true;

    public void SetPos()
    {
        if (GM.youCanAct && Yas)
        {
            Vector3 def = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.gameObject.transform.localPosition = def - offSet;
        }
    }

    public void Click()
    {
        if (firstTime && GM.youCanAct && Yas)
        {
            firstTime = false;
            TTZAnim.Play("Left");
        }
        if (GM.youCanAct && Yas)
        {
            TTZAnim.Play("Left");
        }
    }

    public void Donw()
    {
        if (Read)
        {
            this.transform.localPosition = new Vector2(-5.4063f, 1.224f);
            DS.ListOfPaperSet(PaperG, "https://media.discordapp.net/attachments/828336084798013570/959898680998109274/The_Big_Art.png?width=993&height=559");
            A4.Play();
        }
        else if (GM.youCanAct && Yas)
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
