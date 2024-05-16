using UnityEngine;
using UnityEngine.Playables;

public class TheColader : MonoBehaviour
{
    public bool itAct = true;
    private PlayableDirector cat;
    public GameObject Glitshs;
    public ParticleSystem ps;
    public TheChatDialog TCD;
    public D1SaveManager D1SM;

    public GameObject Light1;
    public Sprite s;

    private void Start()
    {
        cat = gameObject.GetComponent<PlayableDirector>();

        if(D1SM.TheColAct)
        {
            Glitshs.SetActive(false);
            Light1.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = s;
            itAct = false;
        }
    }

    public void StartTheColader()
    {
        itAct = false;
        cat.Play();
        GameManager.uCan = false;
        gameObject.GetComponent<InteractionObject>().IntImgOff();
    }

    public void CamShaceAnim()
    {
        ControllerOfShake.Instance.InstShakeCamera(10f, 5f);
        Glitshs.SetActive(false);
        ps.Play();
    }

    public void catIsEnd()
    {
        GameManager.uCan = true;
        StartCoroutine(TCD.EndKey());
        D1SM.TheColAct = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && itAct)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && itAct)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
