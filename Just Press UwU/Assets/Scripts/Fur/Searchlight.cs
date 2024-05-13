using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searchlight : MonoBehaviour
{
    private AudioSource Au;
    private bool isOn = false;
    void Start()
    {
        Au = transform.Find("Audio Source").GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isOn)
        {
            gameObject.GetComponent<Animator>().SetTrigger("On");
            Au.Play();
            isOn = true;
        }
    }
}
