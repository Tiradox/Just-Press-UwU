using UnityEngine;
using UnityEngine.Playables;

public class DarkRoom : MonoBehaviour
{
    private PlayableDirector gatePd;
    public GameObject gateHitbox;
    private GameObject Player;
    public D1SaveManager D1S;

    public void Start()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
        D1S = GameObject.Find("Saves").GetComponent<D1SaveManager>();
        gatePd = gameObject.GetComponent<PlayableDirector>();

        if (D1S.dorHasOpen)
        {
            DesGate();
            gatePd.Play();
            gatePd.time = 13f;
        }
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }

    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)");
    }

    public void GateAnim()
    {
        if(Player.GetComponent<PlayerSet>().hasGateKey && GameManager.uCan)
        {
            gatePd.Play();
            gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }

    public void DesGate()
    {
        Destroy(gateHitbox);
        D1S.dorHasOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !D1S.dorHasOpen && Player.GetComponent<PlayerSet>().hasGateKey)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
