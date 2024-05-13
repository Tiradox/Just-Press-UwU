using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploutionEffect : MonoBehaviour
{
    public AudioSource As;
    public Vector2 intPos;
    public LayerMask InteractionLayer;
    public float intRange;
    public int damage = 2;

    void Start()
    {
        gameObject.GetComponent<Animator>().SetTrigger("A");
        As.Play();
        Collider2D player = Physics2D.OverlapCircle((Vector2)transform.position + intPos, intRange, InteractionLayer);
        if (player != null) player.GetComponent<PlayerSet>().TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere((Vector2)transform.position + intPos, intRange);
    }
}
