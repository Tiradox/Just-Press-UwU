using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpKey2 : MonoBehaviour
{
    public Color ColorK;
    public UnityEvent ev;
    private bool ispicUp;
    public TheFallDialog TFD;
    public PlayerSet PS;
    public D1SaveManager D1SM;

    private void OnEnable()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }
    public void PlayerInst()
    {
        PS = GameObject.Find("- Player -(Clone)").GetComponent<PlayerSet>();
        if (PS.SpecificKeyPieces[1]) gameObject.SetActive(false);
    }
    public void PicUp()
    {
        if (!ispicUp)
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOff();
            if (!PS.KeyPieces[0]) TFD.FirstUpKey();
            PicUpKey();
        }
    }

    public void PicUpKey()
    {

        transform.Find("Audio Source").GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().color = ColorK;
        ispicUp = true;
        if (!PS.KeyPieces[0]) PS.KeyPieces[0] = true;
        else if (PS.KeyPieces[0] && !PS.KeyPieces[1]) PS.KeyPieces[1] = true;

        if (PS.KeyPieces[0] && PS.KeyPieces[1])
        {
            PS.hasGateKey = true;
            TFD.FirstUpKey2();
        }

        PS.SpecificKeyPieces[1] = true;
    }

    public void DorOpen()
    {
        if (ev != null) ev.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !ispicUp)
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !ispicUp)
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
