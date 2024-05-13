using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcurZoneZone2 : MonoBehaviour
{
    public AudioSource snowyMountains_au;
    public AudioSource au;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            au.mute = true;
            snowyMountains_au.Play();
            GetComponent<Animation>().Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            au.mute = false;
            snowyMountains_au.Stop();
        }
    }
}
