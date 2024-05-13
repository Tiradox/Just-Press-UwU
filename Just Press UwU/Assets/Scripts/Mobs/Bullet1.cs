using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
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
        PlayerSet player = hitInfo.collider.GetComponent<PlayerSet>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Instantiate(impactEffect, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), impactEffect.transform.rotation);
        Destroy(gameObject);
    }
}
