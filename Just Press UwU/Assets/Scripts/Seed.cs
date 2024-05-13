using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Seed : MonoBehaviour
{
    private GameObject Player;
    public Transform TpPoint;
    public GameManager GM;
    public PlayableDirector PD;
    public AudioSource au2;
    public Animator stateDrivenCameraAnim;
    public BossOne BO;
    public GameObject Bg;

    [SerializeField] private bossBatleCam _bossBatleCam;

    private void Start()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;

    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }
    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)");
    }
    public void PicUp()
    {
        Player.GetComponent<PlayerMovement>().itCanRun = false;
        GM.youCanAct = false;
        Player.transform.position = TpPoint.position;
        PD.Play();
        au2.mute = true;
    }

    public void StartOfTheBatle()
    {
        Player.GetComponent<PlayerMovement>().itCanRun = true;
        GM.youCanAct = true;
        StartCoroutine(BatStart());
    }

    private IEnumerator BatStart()
    {
        yield return new WaitForSeconds(1f);
        BO.BatleStart();
    }
}
