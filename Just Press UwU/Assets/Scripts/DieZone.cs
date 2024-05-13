using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieZone : MonoBehaviour
{
    public string tagString;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagString)
        {
            collision.GetComponent<PlayerSet>().Die();
        }
    }
}
