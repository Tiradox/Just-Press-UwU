using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BrokenPunsh : MonoBehaviour
{
    public float jumpForce = 30;
    public bool isBroken = true;
    public Sprite RepTex;
    private float newJumpForce;
    private GameObject PlayerPoint;
    public GameObject Player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool boolPush = false;
    private bool youCanInt = true;
    public AudioSource as2;
    public D1SaveManager D1SM;

    private void Awake()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
    }
    private void Start()
    {
        PlayerPoint = transform.Find("PlayerPoint").gameObject;
        sr = GetComponent<SpriteRenderer>();

        if(D1SM.PunsIsRep)
        {
            isBroken = false;
            sr.sprite = RepTex;
        }    
    }

    void FixedUpdate()
    {
        if (boolPush)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * newJumpForce;
            newJumpForce -= 0.32f;
        }
    }

    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }

    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)");
        rb = Player.GetComponent<Rigidbody2D>();
    }

    public void Activ()
    {
        if (youCanInt && !isBroken)
        {
            this.gameObject.GetComponent<PlayableDirector>().Play();
            Player.transform.position = PlayerPoint.transform.position;
            GameManager.uCan = false;
            youCanInt = false;
            this.gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
        else if (youCanInt && Player.GetComponent<PlayerSet>().RepEl)
        {
            Rep();
        }
    }

    public void Push()
    {
        newJumpForce = jumpForce;
        StartCoroutine(holdJump());
    }

    public void End()
    {
        youCanInt = true;
    }

    private IEnumerator holdJump()
    {
        GameManager.uCan = true;
        boolPush = true;
        yield return new WaitForSeconds(1.7f);
        boolPush = false;
    }

    public void Rep()
    {
        if(Player.GetComponent<PlayerSet>().RepEl)
        {
            isBroken = false;
            sr.sprite = RepTex;
            as2.Play();
            D1SM.PunsIsRep = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Player.GetComponent<PlayerSet>().RepEl)
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
