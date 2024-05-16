using System.Collections;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private Collision coll;

    [HideInInspector]
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 dir;
    public AudioSource BoostAu;
    public CinemachineVirtualCamera CameraRen;
    public SpriteRenderer spriteRenderer;

    [Space]
    [Header("Stats")]
    private float speed = 13;
    private float jumpForce = 14;
    private float dashSpeed = 25;
    public float grSkale = 2;

    [Space]
    public Transform firePoint;
    public GameObject bullet;
    public GameObject flipPoint;
    public AudioSource gunAu;
    public  bool itCanRun = true;
    public float flipCint = 1f;
    private float impulsePov = 0f;
    private GostEffect gostEffect;

    [Space]
    [Header("Shield")]
    public ParticleSystem SPS;
    public GameObject sheald;
    public AudioSource shealdAu;

    private void Awake()
    {
        GlobalEventManager.SendPlayerInst();
        Debug.Log("Отослонно"); 
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
        anim = GetComponent<Animator>();
        BoostAu = transform.Find("Audio Source").GetComponent<AudioSource>();
        CameraRen = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gostEffect = GetComponent<GostEffect>();
        gostEffect.enabled = false;
    }

    void Update()
    {
        if (GameManager.uCan)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            dir = new Vector2(x, y);

            if (itCanRun) Walk(dir);

            if (dir.x > 0 && impulsePov <= 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                flipPoint.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                flipCint = 1f;
            }
            else if (dir.x < 0 && impulsePov <= 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                flipPoint.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                flipCint = -1f;
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (coll.onGround)
                    Jump(Vector2.up);
                else if (coll.doubleJump)
                    DoubleJump(Vector2.up);
            }

            anim.SetFloat("Speed", Mathf.Abs(dir.x));
            anim.SetBool("IsJumping", !coll.onGround);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            anim.SetFloat("Speed", 0);
            anim.SetBool("IsJumping", false);
        }

        if (impulsePov > 0)
        {
            impulsePov -= Time.deltaTime * 15;
            Vector2 impulse = new Vector2(-1, 0f);
            rb.AddForce(impulse * impulsePov * flipCint, ForceMode2D.Impulse);
        }
        else
        {
            itCanRun = true;
            impulsePov = 0f;
        }
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void Jump(Vector2 dir)
    {
        coll.doubleJump = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;
    }

    private void DoubleJump(Vector2 dir)
    {
        coll.doubleJump = false;
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce * 1.5f;
    }

    public void Dash()
    {
        GameManager.uCan = false;
        StartCoroutine(DashWait());
    }

    IEnumerator DashWait()
    {
        anim.SetBool("BOOST", true);
        anim.SetTrigger("BOOST1");
        BoostAu.Play();

        yield return new WaitForSeconds(1.5f);
        anim.SetTrigger("BOOST2");
        rb.velocity = new Vector2(0f, 0f);
        rb.velocity += Vector2.up * dashSpeed;
        speed = 3;
        GameManager.uCan = true;

        rb.gravityScale = 0;
        GetComponent<BetterJumping>().enabled = false;

        yield return new WaitForSeconds(1.6f);
        anim.SetBool("BOOST", false);
        rb.gravityScale = grSkale;
        speed = 13;
        GetComponent<BetterJumping>().enabled = true;
    }

    public void Gun()
    {
        anim.SetBool("BOOST", true);
        anim.SetTrigger("GunSharge");
        StartCoroutine(GunWait());
    }

    IEnumerator GunWait()
    {
        itCanRun = false;
        gostEffect.enabled = true;
        yield return new WaitForSeconds(0.05f);
        ControllerOfShake.Instance.InstShakeCamera(3, 0.2f);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Vector2 impulse = new Vector2(-1, 0f);
        impulsePov = 20f;
        gunAu.Play();
        yield return new WaitForSeconds(1f);
        anim.SetBool("BOOST", false);
        gostEffect.enabled = false;
    }

    public IEnumerator Shield()
    {
        shealdAu.Play();
        sheald.SetActive(true);
        GetComponent<PlayerSet>().shieldOn = true;
        yield return new WaitForSeconds(2f);
        GetComponent<PlayerSet>().shieldOn = false;
        sheald.SetActive(false);
        SPS.Play();
        ControllerOfShake.Instance.InstShakeCamera(3, 0.2f);
    }
}