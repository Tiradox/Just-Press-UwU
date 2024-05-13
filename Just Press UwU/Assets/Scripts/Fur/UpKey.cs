using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpKey : MonoBehaviour
{
    public Color ColorK;
    public UnityEvent ev;
    private bool ispicUp;
    public TheFallDialog TFD;
    public PlayerSet PS;
    public D1SaveManager D1SM;

    private void OnEnable()
    {
        GlobalEventManager.OnAbilityLoadad += PlayerInst;
    }
    private void OnDisable()
    {
        GlobalEventManager.OnAbilityLoadad -= PlayerInst;
    }
    public void PlayerInst()
    {
        PS = GameObject.Find("- Player -(Clone)").GetComponent<PlayerSet>();
        if (PS.SpecificKeyPieces[0])
        {
            Debug.Log("Ключь был подобран >> открытие двери");
            DorOpen();
            gameObject.SetActive(false);
        }
    }

    public void PicUp()
    {
        if(!ispicUp)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOff();
            if(!PS.KeyPieces[0]) TFD.FirstUpKey();
            PicUpKey();
            DorOpen();
        }
    }

    public void PicUpKey()
    {

        transform.Find("Audio Source").GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().color = ColorK;
        ispicUp = true;
        if(!PS.KeyPieces[0]) PS.KeyPieces[0] = true;
        else if (PS.KeyPieces[0] && !PS.KeyPieces[1]) PS.KeyPieces[1] = true;

        if(PS.KeyPieces[0] && PS.KeyPieces[1])
        {
            PS.hasGateKey = true;
            TFD.FirstUpKey2();
        }

        PS.SpecificKeyPieces[0] = true;
        Debug.Log("Ключь подобран: " + PS.SpecificKeyPieces[0]);
    }

    public void DorOpen()
    {
        if (ev != null) ev.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !ispicUp)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !ispicUp)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
