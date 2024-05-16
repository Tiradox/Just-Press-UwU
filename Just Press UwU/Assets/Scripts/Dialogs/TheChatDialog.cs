using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheChatDialog : MonoBehaviour
{
    public DialogueSystem DS;
    protected List<string> fileLines4;
    public D1SaveManager D1SM;

    //Мировые

    public void Dialog1()
    {
        if (!D1SM.сhatDialogs[0]) StartCoroutine(D1());
    }
    public void Dialog2()
    {
        if (!D1SM.сhatDialogs[1]) StartCoroutine(D2());
    }
    public void Dialog3()
    {
        if (!D1SM.сhatDialogs[2]) StartCoroutine(D3());
    }
    public void Dialog4()
    {
        if (!D1SM.сhatDialogs[3]) StartCoroutine(D4());
    }
    private IEnumerator D1()
    {
        D1SM.сhatDialogs[0] = true;
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\d1.txt");
        TheT.Chat.SendMes(fileLines4[0], false);
        yield return new WaitForSeconds(3f);
        TheT.Chat.SendMes(fileLines4[1], false);
        yield return new WaitForSeconds(3f);
        TheT.Chat.SendMes(fileLines4[2], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[3], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[4], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[5], false);
        yield return new WaitForSeconds(7f);
        TheT.Chat.SendMes(fileLines4[6], false);
        yield return new WaitForSeconds(8f);
        TheT.Chat.SendMes(fileLines4[7], true);
    }
    private IEnumerator D2()
    {
        D1SM.сhatDialogs[1] = true;
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\d2.txt");
        int len = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).GetFiles().Length;
        if (len == 0)
        {
            TheT.Chat.SendMes(fileLines4[0] + len.ToString() + fileLines4[1], false);
            yield return new WaitForSeconds(4f);
            TheT.Chat.SendMes(fileLines4[3], true);
        }
        else if(len>=1 && len <= 39)
        {
            TheT.Chat.SendMes(fileLines4[0] + len.ToString() + fileLines4[1], false);
            yield return new WaitForSeconds(4f);
            TheT.Chat.SendMes(fileLines4[4], true);
        }
        else if (len >= 40 && len <= 99)
        {
            TheT.Chat.SendMes(fileLines4[0] + len.ToString() + fileLines4[1], false);
            yield return new WaitForSeconds(4f);
            TheT.Chat.SendMes(fileLines4[2], true);
        }
        else if (len >= 100)
        {
            TheT.Chat.SendMes(fileLines4[5] + len.ToString() + fileLines4[6], true);
        }
    }

    public IEnumerator D3()
    {
        D1SM.сhatDialogs[2] = true;
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\d3.txt");
        TheT.Chat.SendMes(fileLines4[0] + Environment.UserName + fileLines4[1], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[2], true);
    }
    public IEnumerator D4()
    {
        D1SM.сhatDialogs[3] = true;
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\d4.txt");
        for (int i = 0; i!= 6; i++)
        {
            TheT.Chat.SendMes(fileLines4[i], false);
            yield return new WaitForSeconds(3f);
        }
        TheT.Chat.SendMes(fileLines4[7], true);
    }

    public void AbTakeDialoge()
    {
        StartCoroutine(AbTakeDialog());
    }
    private IEnumerator AbTakeDialog()
    {

        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\abTakeDialoge.txt");
        yield return new WaitForSeconds(1f);
        TheT.Chat.SendMes(fileLines4[0], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[1], false);
        yield return new WaitForSeconds(3f);
        TheT.Chat.SendMes(fileLines4[2], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[3], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[4], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[5], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[6], false);
        yield return new WaitForSeconds(2f);
        TheT.Chat.SendMes(fileLines4[7], false);
        yield return new WaitForSeconds(2f);
        TheT.Chat.SendMes(fileLines4[8], false);
        yield return new WaitForSeconds(2f);
        TheT.Chat.SendMes(fileLines4[9], true);
    }

    public IEnumerator EndKey()
    {
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\endKey.txt");
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[0], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[1], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[2], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[3], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[4], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[5], false);
        yield return new WaitForSeconds(5f);
        TheT.Chat.SendMes(fileLines4[6], true);
    }

    public IEnumerator TheBossDialog()
    {
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\TheBossDialog.txt");

        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[0], false);
        yield return new WaitForSeconds(6f);
        TheT.Chat.SendMes(fileLines4[1], true);
    }
    public IEnumerator TheBossDialog2()
    {
        //fileLines4 = DS.DraftingАProposal(@"Dialogues\Chat\World\TheBossDialog.txt");

        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[2], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[3], false);
        yield return new WaitForSeconds(4f);
        TheT.Chat.SendMes(fileLines4[4], true);
    }
}
