using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowBullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public LayerMask CollLayers;
    public float distense;
    public GameObject impactEffect;

    private void Start()
    {
        StartCoroutine(I());
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distense, CollLayers);
        if (hitInfo.collider != null)
        {
            Hit();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Hit()
    {
        Instantiate(impactEffect, new Vector3(transform.position.x, transform.position.y, impactEffect.transform.position.z), impactEffect.transform.rotation);
        Destroy(gameObject);
    }

    private IEnumerator I()
    {
        yield return new WaitForSeconds(5f);
        Hit();
    }
}
