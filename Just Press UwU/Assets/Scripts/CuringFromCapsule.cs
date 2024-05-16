using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using TMPro;

public class CuringFromCapsule : MonoBehaviour
{
    private bool DorOpen = false;
    public TMP_Text exitTxt;
    public PlayableDirector Cat;
    public AudioSource Au1;
    public AudioSource Au2;
    public Animator dorAnim;
    public Rigidbody2D dorrRb;
    public GameObject Player;
    public Transform PlayerPiont;
    public Animator stateDrivenCamAnim;
    public bool YouKanOut = false;
    public TheFallDialog TFD;
    protected List<string> fileLines;
    public DialogueSystem DS;

    public D1SaveManager D1S;

    void Start()
    {
        if(!D1S.itFell)
        {
            stateDrivenCamAnim.SetTrigger("DC");
            Cat.Play();
            GameManager.uCan = false;

            fileLines = DS.DraftingАProposal(@"UI\ExitTxt.txt");
            exitTxt.text = fileLines[0];
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !DorOpen && YouKanOut)
        {
            DorOpen = true;
            exitTxt.gameObject.SetActive(false);
            StartCoroutine(Open());
        }    
    }

    private IEnumerator Open()
    {
        Au1.Play();
        dorAnim.SetTrigger("НахДверь");
        yield return new WaitForSeconds(1.5f);
        stateDrivenCamAnim.SetTrigger("MC");
        Au2.Play();
        dorrRb.simulated = true;
        dorrRb.AddForce(Vector2.right * 25, ForceMode2D.Impulse);
        dorrRb.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -15.43f);
        Instantiate(Player, PlayerPiont.position, Quaternion.Euler(0f,0f,0f));
        yield return new WaitForSeconds(1f);
        TFD.Dialog1();
    }

    public void EndCat()
    {
        YouKanOut = true;
    }
}
