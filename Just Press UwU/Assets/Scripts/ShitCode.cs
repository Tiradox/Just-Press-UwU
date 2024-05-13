using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShitCode : MonoBehaviour
{
    private string cheatString = "DDZP01ZTGX";
    private string cheatString2 = "ВВЯЗ01ЯЕПЧ";
    public string inputcheat = " ";
    private int printedLetters = 0;
    private bool fuse = false;

    void Update()
    {
        if(Input.anyKeyDown && Input.inputString!="" && !fuse)
        {
            inputcheat += Input.inputString;
            cheatQualifier();
        }
    }

    private void cheatQualifier()
    {
        if (inputcheat.ToUpper() == cheatString || inputcheat.ToUpper() == cheatString2)
        {
            fuse = true;
            SceneManager.LoadScene("shitcode");
        }
        if(inputcheat.ToUpper()[printedLetters] == cheatString[printedLetters] || inputcheat.ToUpper()[printedLetters] == cheatString2[printedLetters])
        {
            printedLetters++;
        }
        else
        {
            printedLetters = 0;
            inputcheat = "";
        }
    }
}
