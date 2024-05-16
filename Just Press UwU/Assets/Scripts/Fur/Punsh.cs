using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Punsh : MonoBehaviour
{
    public float jumpForce = 30;
    private float newJumpForce;
    private GameObject PlayerPoint;
    public GameObject Player;
    private Rigidbody2D rb;
    private PlayableDirector _playableDirector;
    private InteractionObject _interactionObject;
    private bool boolPush = false;
    private bool youCanInt = true;

    private void Awake()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
        PlayerPoint = transform.Find("PlayerPoint").gameObject;
        _playableDirector = GetComponent<PlayableDirector>();
        _interactionObject = GetComponent<InteractionObject>();
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }

    void FixedUpdate()
    {
        if(boolPush)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * newJumpForce;
            newJumpForce -= 0.32f;
        }
    }

    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)");
        rb = Player.GetComponent<Rigidbody2D>();
    }

    public void Activ()
    {
        if (youCanInt)
        {
            _playableDirector.Play();
            Player.transform.position = PlayerPoint.transform.position;
            GameManager.uCan = false;
            youCanInt = false;
            _interactionObject.IntImgOff();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _interactionObject.IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _interactionObject.IntImgOff();
        }
    }

    public void Restore()
    {
        if(_playableDirector.time < 12 && !youCanInt)
        {
            _playableDirector.time = 12;
        }
    }
}
