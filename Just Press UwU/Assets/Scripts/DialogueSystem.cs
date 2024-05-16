using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject letter;

    public Animator MesBoxAnimator;
    [SerializeField] private TMP_Text MesBoxText;
    [SerializeField] private TMP_Text MesBoxName;
    [SerializeField] public GameObject MesBoxStrel;
    [SerializeField] private AudioSource AU;

    protected List<string> fileLines;

    public bool YouCanCont = false;
    public bool DialogueIsGo = false;

    private string _currentText;

    public List<string> DraftingАProposal(string path)
    {
        path = Application.streamingAssetsPath + "/_Text/" + SettingsSaveManager.settingsSave.LanguageCode + "/" + path;
        fileLines = File.ReadAllLines(path).ToList();
        return (fileLines);
    }
    public List<string> DraftingАProposalRoot(string path)
    {
        path = Application.streamingAssetsPath + "/081/" + path;
        fileLines = File.ReadAllLines(path).ToList();
        return (fileLines);
    }

    public IEnumerator SimplePrintTxt(List<string> fileLines, TMP_Text txt, int LineNumber, float speedTxt)
    {
        YouCanCont = false;
        for (int i = 0; i != fileLines[LineNumber].Length; i++)
        {
            txt.text += fileLines[LineNumber][i];
            yield return new WaitForSeconds(speedTxt);
        }
        YouCanCont = true;
    }

    public IEnumerator SimplePrintTxtEndStrel(List<string> fileLines, TMP_Text txt, int LineNumber, float speedTxt, GameObject endStrel)
    {
        _currentText = fileLines[LineNumber];
        for (int i = 0; i != _currentText.Length; i++)
        {
            txt.text += _currentText[i];
            yield return new WaitForSeconds(speedTxt);
        }
        YouCanCont = true;
        endStrel.SetActive(true);
    }


    public void PrintTxt(List<string> fileLines, int LineNumber, GameObject im)
    {
        for (int i = 0; i != fileLines[((LineNumber + 1) * 3) - 2].Length; i++)
        {
            GameObject JLetter = Instantiate(letter) as GameObject;
            JLetter.transform.SetParent(im.transform, false);
            JLetter.GetComponentInChildren<Text>().text = Convert.ToString(fileLines[((LineNumber + 1) * 3) - 2][i]);
            JLetter.GetComponent<Letter>().identifier = Convert.ToString(fileLines[((LineNumber + 1) * 3) - 1][i]);
        }
    }

    public IEnumerator TxtAnimation(List<string> fileLines, int LineNumber, GameObject im, float speedTxt, bool TheEnd)
    {
        for (int i = 0; i != fileLines[((LineNumber + 1) * 3) - 2].Length; i++)
        {
            yield return new WaitForSeconds(speedTxt);
            im.transform.GetChild(i).GetComponent<Letter>().ActivationL();
        }
        if (TheEnd) GameManager.uCan = true;
    }
    public IEnumerator TxtAnimation(List<string> fileLines, int LineNumber, GameObject im, float speedTxt, int txtShift, bool TheEnd)
    {
        for (int i = 0 + txtShift; i != fileLines[((LineNumber + 1) * 3) - 2].Length + txtShift; i++)
        {
            yield return new WaitForSeconds(speedTxt);
            im.transform.GetChild(i).GetComponent<Letter>().ActivationL();
        }
        if (TheEnd) GameManager.uCan = true;
    }

    public void DESTROYTxt(List<string> fileLines, int LineNumber, GameObject im)
    {
        for (int i = 0; i != fileLines[((LineNumber + 1) * 3) - 2].Length; i++)
        {
            StartCoroutine(im.transform.GetChild(i).GetComponent<Letter>().Des());
        }
    }

    public void DESTROYTxt(List<string> fileLines, int LineNumber, GameObject im, int LineNumber2)
    {
        for (int i = 0; i != fileLines[((LineNumber + 1) * 3) - 2].Length + fileLines[((LineNumber2 + 1) * 3) - 2].Length; i++)
        {
            StartCoroutine(im.transform.GetChild(i).GetComponent<Letter>().Des());
        }
    }

    //Чтиво
    public void ListOfPaperSet(GameObject GO, string t)
    {
        Text T = GO.GetComponentInChildren<Text>();
        T.text = t;
        GO.SetActive(true);
    }
    public void ListOfPaperExit(GameObject GO)
    {
        GO.SetActive(false);
    }

    //Обычное оснащение текста Masege
    public void MesOpen(List<string> fileLines, string name, int LineNumber, float speedTxt)
    {
        MesBoxAnimator.SetTrigger("On");
        MesPrint(fileLines, name, LineNumber, speedTxt, false);
        DialogueIsGo = true;
    }

    public void MesExit()
    {
        MesBoxAnimator.SetTrigger("Off");
        DialogueIsGo = false;
    }
    public void MesPrint(List<string> fileLines, string name, int LineNumber, float speedTxt, bool isThisNext)
    {
        MesBoxName.text = name;
        MesBoxText.text = "";
        StartCoroutine( SimplePrintTxtEndStrel(fileLines, MesBoxText, LineNumber, speedTxt, MesBoxStrel));

        if(isThisNext)
        {
            MesBoxAnimator.GetComponent<Animator>().SetTrigger("Next");
            AU.Play();
        }
    }

    public void ToEnd()
    {
        StopAllCoroutines();
        MesBoxText.text = _currentText;
    }
}
