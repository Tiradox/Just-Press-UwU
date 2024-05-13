using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkScript : MonoBehaviour
{
    public Animator DarkAnim;
    public Animator GLAnim;
    public AudioSource MainMus;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            DarkAnim.SetTrigger("On");
            GLAnim.SetTrigger("On");
            MainMus.mute = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DarkAnim.SetTrigger("Off");
            GLAnim.SetTrigger("Off");
            MainMus.mute = false;
        }
    }
}
