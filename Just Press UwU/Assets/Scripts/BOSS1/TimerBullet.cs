using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerBullet : MonoBehaviour
{
    public float StartTmie = 0.2f;
    public float WheitTime = 1f;
    public float StartSpeed = 50f;
    public float LowSpeed = 2f;
    public float speed = 30f;
    private float finelSpeed;
    public Rigidbody2D rb;
    public LayerMask CollLayers;
    public LayerMask GroundLayer;
    public float damage;
    public float distense;
    public GameObject impactEffect;
    public Sprite s1;
    public Sprite s2;

    private void Start()
    {
        finelSpeed = StartSpeed;
        StartCoroutine(StartWheit());
    }
    
    private IEnumerator StartWheit()
    {
        yield return new WaitForSeconds(StartTmie);
        finelSpeed = LowSpeed * -1;
        GetComponent<SpriteRenderer>().sprite = s2;
        yield return new WaitForSeconds(WheitTime);
        finelSpeed = speed;
        transform.Find("Audio Source 2").GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = s1;
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distense, CollLayers);
        if (hitInfo.collider != null)
        {
            Hit(hitInfo);
        }

        transform.Translate(Vector2.right * finelSpeed * Time.deltaTime);
    }

    private void Hit(RaycastHit2D hitInfo)
    {
        PlayerSet player = hitInfo.collider.GetComponent<PlayerSet>();

        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Instantiate(impactEffect, new Vector3(transform.position.x, transform.position.y + 3.2f, transform.position.z), impactEffect.transform.rotation);
        Destroy(gameObject);
    }
}
