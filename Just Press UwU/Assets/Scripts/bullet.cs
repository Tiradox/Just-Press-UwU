using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public LayerMask CollLayers;
    public float damage;
    public float distense;
    public GameObject impactEffect;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distense, CollLayers);
        if (hitInfo.collider != null)
        {
            Hit(hitInfo);
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Hit(RaycastHit2D hitInfo)
    {
        Enemy enemy = hitInfo.collider.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
