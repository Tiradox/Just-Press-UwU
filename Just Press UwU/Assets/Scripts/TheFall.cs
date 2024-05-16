using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class TheFall : MonoBehaviour
{
    public PlayableDirector Cat;
    public DialogueSystem DS;

    public TMP_Text mainTxt;
    protected List<string> fileLines;
    public int inp;

    public float fallTime;
    public Text timeTxt;
    public bool startFall = false;

    void Start()
    {
        StartCoroutine(StartS());
    }
    private void Update()
    {
        if(startFall && fallTime > 0)
        {
            fallTime -= Time.deltaTime;
            timeTxt.text = fileLines[8] + "\n" + fallTime;
        }
        else if (startFall && fallTime < 0)
        {
            timeTxt.text = fileLines[8] + "\n0";
        }
    }

    private IEnumerator StartS()
    {
        fileLines = DS.DraftingАProposal(@"Dialogues\TheFall\Dictor.txt");
        yield return new WaitForSeconds(1f);
        Cat.Play();
    }

    public void SpamText()
    {
        StartCoroutine(DS.SimplePrintTxt(fileLines, mainTxt, inp, 0.03f));
        inp++;
    }

    public void DesText()
    {
        mainTxt.text = "";
    }

    public void StartFall()
    {
        startFall = true;
    }

    public void EndCat()
    {
        SceneManager.LoadScene("RL1");
    }
}
