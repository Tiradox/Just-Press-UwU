using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public int SaveInt;
    private GameObject Player;
    public Sprite S;
    public AudioSource Au;
    public D1SaveManager D1S;
    private Transform spavnPoint;
    public GameObject PlayerPrafab;
    private TheFallDialog TFD;
    private GameObject connectionRestoredTex;

    private void Start()
    {
        spavnPoint = transform.Find("SpavnPoint").GetComponent<Transform>();
        TFD = GameObject.Find("TheFallDialog").GetComponent<TheFallDialog>();
        connectionRestoredTex = GameObject.Find("ConnectionRestoredTex");

        if (D1S.spavnPlase == SaveInt && D1S.itFell)
        {
            Instantiate(PlayerPrafab, spavnPoint.position, Quaternion.Euler(0f, 0f, 0f));
            connectionRestoredTex.GetComponent<Animation>().Play();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = S;
        }
    }

    private void OnEnable()
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

    public void SetSave()
    {
        if (!D1S.itFell)
        {
            TFD.Dialog2();
        }
        GameManager.uCan = false;
        StartCoroutine(SaveAnim());
        D1S.spavnPlase = SaveInt;
        D1S.spavnPlaseName = SceneManager.GetActiveScene().name;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = S;
        Au.Play();
        D1S.SaveSettings();
        Player.GetComponent<PlayerSet>().SaveSettings();
        this.gameObject.GetComponent<InteractionObject>().IntImgOff();

        Player.GetComponent<PlayerSet>().FullRegen();
    }

    private IEnumerator SaveAnim()
    {
        Player.GetComponent<Animator>().SetTrigger("Save");
        yield return new WaitForSeconds(0.8f);
        if (D1S.itFell)
        {
            GameManager.uCan = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
