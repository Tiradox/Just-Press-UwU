using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBotZone : MonoBehaviour
{
    public string tagString;
    public TargetBot BotAI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagString)
        {
            BotAI.setTarget(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == tagString)
        {
            BotAI.resetTarget();
        }
    }
}
