using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public UnityEvent e;
    private bool itOn;

    public void LeverOn()
    {
        if(!itOn)
        {
            GetComponent<Animator>().SetTrigger("On");
            transform.Find("Audio Source").GetComponent<AudioSource>().Play();
            e.Invoke();
            itOn = true;
        }
    }

    public void LeverOff()
    {
        GetComponent<Animator>().SetTrigger("Off");
        itOn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
