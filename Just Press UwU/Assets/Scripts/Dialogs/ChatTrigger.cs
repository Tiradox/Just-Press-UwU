using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChatTrigger : MonoBehaviour
{
    public string tagString;
    public UnityEvent a;
    public UnityEvent b;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagString && a != null)
        {
            a.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tagString && b != null)
        {
            b.Invoke();
        }
    }
}
