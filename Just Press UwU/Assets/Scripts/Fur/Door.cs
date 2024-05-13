using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen;

    public void Open()
    {
        if(!isOpen)
        {
            isOpen = true;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.Find("Audio Source").GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetTrigger("out");
        }
    }

    public void Close()
    {
        if(isOpen)
        {
            isOpen = false;
            GetComponent<BoxCollider2D>().enabled = true;
            transform.Find("Audio Source 2").GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetTrigger("in");
        }
    }
}
