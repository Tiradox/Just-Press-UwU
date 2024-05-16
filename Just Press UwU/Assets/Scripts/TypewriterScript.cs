using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TypewriterScript : MonoBehaviour
{
    public AudioSource ClickAS;
    public AudioSource UpAS;
    private bool isOpen;
    public PlayableDirector Cat3;
    public PlayableDirector Cat4;
    public Ticket Ti;
    public Ticket2 Ti2;
    protected List<string> fileLines;
    protected List<string> fileLines2;
    public string path;
    public DialogueSystem DS;
    public Text readTex;
    public bool end;
    

    public void Start()
    {
        fileLines = DS.DraftingАProposal("UI/Ty.txt");
        readTex.text = fileLines[0];
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

    public void OpenT()
    {
        fileLines2 = DS.DraftingАProposalRoot("root_files/not identified 3/[ Typewriter ].txt");
        if (!isOpen && GameManager.uCan)
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("Open");
            ClickAS.Play();
            isOpen = true;
            StartCoroutine(Ct3());
        }
        if (isOpen && GameManager.uCan && !Ti.firstTime && fileLines2[0] == "What to print? >su_file.qr" && !end)
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
