using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlatformerShec : MonoBehaviour
{
    private Vector2 TpPoint;
    private ParticleSystem ps;
    private Animator anim;
    private AudioSource au;
    private AudioSource au2;
    private Animation tpCamAnim;
    private bool youCanTp;

    private GameObject _player;

    [SerializeField] private UnityEvent _resoreEvent;

    private void Awake()
    {
        TpPoint = transform.Find("TpPoint").transform.position;
        ps = transform.Find("TpPoint").transform.Find("Particle System").GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        au = transform.Find("Audio Source").GetComponent<AudioSource>();
        au2 = transform.Find("Audio Source 2").GetComponent<AudioSource>();
        tpCamAnim = transform.Find("Global Volume").GetComponent<Animation>();
        GlobalEventManager.OnPlayerInst += OnPlayerInst;
        youCanTp = true;
    }

    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= OnPlayerInst;
    }

    private void OnPlayerInst()
    {
        _player = GameObject.Find("- Player -(Clone)");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && youCanTp)
        {
            anim.SetTrigger("open");
            StartCoroutine(TpIEnumerator());
            au2.Play();
            youCanTp = false;
        }
    }


    private IEnumerator TpIEnumerator()
    {
        yield return new WaitForSeconds(1f);
        Teleport();
    }

    public void Teleport()
    {
        ps.Play();
        au.Play();
        _player.transform.position = TpPoint;
        tpCamAnim.Play();
        youCanTp = true;
        _player.GetComponent<PlayerSet>().platformerTp = TpPoint;
        _player.GetComponent<PlayerSet>().platformerRestoreEvent = _resoreEvent;
    }
}
