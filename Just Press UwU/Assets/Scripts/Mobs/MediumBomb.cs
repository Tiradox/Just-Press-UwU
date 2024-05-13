using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBomb : MonoBehaviour
{
    public GameObject Ex;
    public float speed = 2.5f;
    public bool onGround;
    private bool onDes;
    public Sprite[] sp = new Sprite[6];
    private bool JasBoom = false;
    private bool pic = true;

    [Space]

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public float collisionRadius2 = 0.25f;
    public Vector2 bottomOffset;
    public Color debugCollisionColor = Color.red;
    public LayerMask groundLayer;
    public Vector2 target;
    public AudioSource au1;
    public AudioSource au2;

    public void DieEv()
    {
        Instantiate(Ex, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onDes = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius2, groundLayer);

        if (onGround)
        {
            target = GameObject.Find("- Player -(Clone)").transform.position;
            if (pic)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sp[1];
                au1.Play();
                pic = false;
            }

            if (onDes)
            {
                transform.position = Vector3.Lerp(transform.position, target, speed * Time.fixedDeltaTime);
                if(!JasBoom)
                {
                    JasBoom = true;
                    StartCoroutine( Boom());
                }
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sp[0];
            pic = true;
        }
    }

    private IEnumerator Boom()
    {
        au2.Play();
        gameObject.GetComponent<SpriteRenderer>().sprite = sp[2];
        yield return new WaitForSeconds(1f);
        DieEv();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        var positions = new Vector2[] { bottomOffset };
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);

        Gizmos.color = debugCollisionColor;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius2);
    }

}
