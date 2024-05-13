using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieScreenManager : MonoBehaviour
{
    public GameManager GM;
    public DialogueSystem DS;
    protected List<string> fileLines;
    public Text txt1;
    public Text txt2;
    public GameObject s;
    public AudioSource au;
    public AudioSource au2;

    public void Start()
    {
        fileLines = DS.DraftingАProposal("UI/Die.txt");
        StartCoroutine(IETex());
        txt2.text = fileLines[2];
    }

    IEnumerator IETex()
    {
        while(true)
        {
            txt1.text = fileLines[0];
            yield return new WaitForSeconds(0.5f);
            txt1.text = fileLines[1];
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnButtonEnter()
    {
        s.SetActive(true);
        au.Play();
        au2.Play();
    }
    public void OnButtonExit()
    {
        s.SetActive(false);
        au.Stop();
    }
    public void OnButtonDown()
    {
        Application.Quit();
    }
}
