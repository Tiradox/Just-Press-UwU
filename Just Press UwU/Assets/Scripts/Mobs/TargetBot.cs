using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBot : MonoBehaviour
{
    private Animator anim;
    public Transform target;
    public GameObject bulletPrefab;
    public Transform bulletPoint;
    public AudioSource au;
    public GameObject Ex;

    private void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if(target!=null)
        {
            if (target.position.x > transform.position.x)
            {
                anim.SetBool("isRight", true);
            }
            else if (target.position.x <= transform.position.x)
            {
                anim.SetBool("isRight", false);
            }
        }
    }

    public void setTarget(Collider2D collision)
    {
        target = collision.transform;
        StartCoroutine(GunIE());
    }

    public void resetTarget()
    {
        StopAllCoroutines();
    }

    private IEnumerator GunIE()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            au.Play();
            yield return new WaitForSeconds(1f);
        }
    }

    public void TakeDamage()
    {
        anim.SetTrigger("TakeDamage");
    }

    public void Die()
    {
        Instantiate(Ex, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
