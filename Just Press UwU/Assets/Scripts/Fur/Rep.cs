using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rep : MonoBehaviour
{
    public D1SaveManager D1SM;
    private GameManager GM;
    private GameObject Player;

    private void Start()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if(D1SM.RepIsUp)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }

    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)");
    }

    public void PicUp()
    {
        D1SM.RepIsUp = true;
        Player.GetComponent<PlayerSet>().RepEl = true;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
