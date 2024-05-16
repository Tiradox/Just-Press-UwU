using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using Tiradox;

public class TypewriterScript : MonoBehaviour
{
    public AudioSource ClickAS;
    public AudioSource UpAS;
    private bool isOpen;
    public PlayableDirector Cat3;
    public PlayableDirector Cat4;
    public Ticket Ti;
    public Ticket2 Ti2;
    public string path;
    public DialogueSystem DS;
    public Text readTex;
    public bool end;

    private void Start()
    {
        readTex.text = LocalizationManager.GetText("Read");
    }

    public void UpT()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Up");
        UpAS.Play();
    }

    public void END2()
    {
        System.IO.Directory.Delete(Application.streamingAssetsPath + "/081", true);
        Application.Quit();
    }

    public void Print()
    {
        if (!GameManager.uCan) return;

        if (!isOpen)
        {
            GetComponent<Animator>().SetTrigger("Open");
            ClickAS.Play();
            isOpen = true;
            StartCoroutine(Ct3());
        }
        if (isOpen && !Ti.firstTime && FileHelper.Read("") == "What to print? >su_file.qr" && !end)
        {
            GameManager.uCan = false;
            Cat4.Play();
            end = true;
        }
    }

    private IEnumerator Ct3()
    {
        GameManager.uCan = false;
        yield return new WaitForSeconds(2.5f);
        Cat3.Play();
    }

    public void EndCt3()
    {
        GameManager.uCan = true;
        Ti.Yas = true;
    }

    public void EndCt4()
    {
        GameManager.uCan = true;
        Ti2.Yas = true;
    }
}
