using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.Events;

public class MusicMan : MonoBehaviour
{
    [SerializeField] private bool _turnOnAudioAfterPlay = true;
    [SerializeField] private UnityEvent _afterPlayEvent;
    [SerializeField] private float _eventDilay;

    [Space]
    public AudioSource MainAu;
    private bool itPlay;
    public int whatIsThisMusicMan;
    private D1SaveManager D1S;
    private Animator musicManCountAnim;
    public Sprite endSprite;
    private GameObject Player;
    public GameUiManager GUM;
    public AudioSource Au;


    void Start()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
        D1S = GameObject.Find("Saves").GetComponent<D1SaveManager>();
        musicManCountAnim = GameObject.Find("MusicMansCount").GetComponent<Animator>();

        if (D1S.MusicMans[whatIsThisMusicMan]) SetSave();
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }
    private void SetSave()
    {
        GetComponent<SpriteRenderer>().sprite = endSprite;
        itPlay = true;
    }

    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)");
    }

    public void PlayMusic()
    {
        if(!itPlay)
        {
            GetComponent<PlayableDirector>().Play();
            MainAu.mute = true;
            itPlay = true;
            gameObject.GetComponent<InteractionObject>().IntImgOff();
            GameManager.uCan = false;
        }
    }

    public void EndPlay()
    {
        GameManager.uCan = true;
        if(_turnOnAudioAfterPlay)
        {
            MainAu.mute = false;
        }
        D1S.MusicMans[whatIsThisMusicMan] = true;
        MMSOn();

        if(D1S.MusicMansInt==8)
        {
            Player.GetComponent<PlayerSet>().аbility[2] = true;
            Au.Play();
            GUM.SetAb();
        }

        if (_afterPlayEvent != null) StartCoroutine(EventWheit());
    }

    private IEnumerator EventWheit()
    {
        yield return new WaitForSeconds(_eventDilay);
        _afterPlayEvent.Invoke();
    }

    public void MMSOn()
    {
        D1S.MusicMansInt++;
        musicManCountAnim.gameObject.GetComponent<Text>().text = D1S.MusicMansInt + "/8";
        musicManCountAnim.SetTrigger("MMCOn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !itPlay)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !itPlay)
        {
            gameObject.GetComponent<InteractionObject>().IntImgOff();
        }
    }
}
