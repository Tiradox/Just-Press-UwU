using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcurZoneZone : MonoBehaviour
{
    public AudioSource snowyMountains_au;
    public AudioSource au;
    public GameUiManager GUM;
    public GameObject blockedText;
    public D1SaveManager D1SM;
    public GameObject InputObj;

    private void Start()
    {
        if(D1SM.ParcurIsEnd) InputObj.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            collision.gameObject.GetComponent<PlayerMovement>().grSkale = 3;
            au.mute = true;
            snowyMountains_au.Play();
            GUM.youCanUseIt = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
            collision.gameObject.GetComponent<PlayerMovement>().grSkale = 2;
            au.mute = false;
            snowyMountains_au.Stop();
            GUM.youCanUseIt = true;
        }
    }
}
