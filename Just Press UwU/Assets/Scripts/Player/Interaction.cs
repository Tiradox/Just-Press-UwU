using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [Header("Collision2")]
    public Vector2 intPos;
    public LayerMask InteractionLayer;
    public Vector2 intRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.uCan)
        {
            Collider2D furnet = Physics2D.OverlapBox((Vector2)transform.position + intPos, intRange, 0f, InteractionLayer);
            if (furnet != null) furnet.GetComponent<InteractionObject>().ActivateInt();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube((Vector2)transform.position + intPos, intRange);
    }

}
