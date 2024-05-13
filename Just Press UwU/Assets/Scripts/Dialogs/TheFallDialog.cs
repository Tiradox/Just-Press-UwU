using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheFallDialog : MonoBehaviour
{
    public GameManager GM;
    public DialogueSystem DS;
    public CuringFromCapsule CFC;
    public TheChatDialog TCD;
    protected List<string> fileLines;

    public int WTD = 0;

    public Action d;


    //Доп
    public GameObject Barrier;
    public Checkpoint Ch;
    public D1SaveManager D1S;
    public Animator stateDrivenCameraAnim;
    public UpKey UK;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && DS.YouCanCont && DS.DialogueIsGo)
        {
            DS.MesBoxStrel.SetActive(false);
            DS.YouCanCont = false;
            d.Invoke();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !DS.YouCanCont && DS.DialogueIsGo)
        {
            DS.YouCanCont = true;
            DS.ToEnd();
        }
    }

    public void Dialog1()
    {
        if (WTD == 0)
        {
            d = Dialog1;
            Barrier.SetActive(true);
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\TheFallExit.txt");
            DS.MesOpen(fileLines, fileLines[0], 1, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 2, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 3, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesPrint(fileLines, fileLines[0], 4, 0.03f, true);
            WTD = 4;
        }
        else if (WTD == 4)
        {
            DS.MesExit();
            GM.youCanAct = true;
            WTD = 0;
        }
    }

    public void Dialog2()
    {
        if (WTD == 0)
        {
            GM.youCanAct = false;
            d = Dialog2;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\TheFallExit2.txt");
            DS.MesOpen(fileLines, fileLines[0], 1, 0.03f);
            WTD = 1;
        }
        else if (WTD >= 1 && WTD <= 11)
        {
            DS.MesPrint(fileLines, fileLines[0], WTD + 1, 0.03f, true);
            WTD++;
        }
        else if (WTD == 12)
        {
            D1S.itFell = true;
            DS.MesExit();
            WTD = 0;
            Barrier.SetActive(false);
            Ch.SetSave();
            GM.stage = 3;
            GM.SaveSettings();
        }

    }

    public void Dialog3()
    {
        if (WTD == 0 && !D1S.triggerDialoge[0])
        {
            GM.youCanAct = false;
            d = Dialog3;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\TheDoor.txt");
            DS.MesOpen(fileLines, fileLines[0], 1, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 2, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 3, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesPrint(fileLines, fileLines[0], 4, 0.03f, true);
            WTD = 4;
        }
        else if (WTD == 4)
        {
            DS.MesPrint(fileLines, fileLines[0], 5, 0.03f, true);
            WTD = 5;
        }
        else if (WTD == 5)
        {
            DS.MesExit();
            GM.youCanAct = true;
            D1S.triggerDialoge[0] = true;
            WTD = 0;
        }
    }

    public void Dialog4()
    {
        if (WTD == 0 && !D1S.triggerDialoge[1])
        {
            GM.youCanAct = false;
            d = Dialog4;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\TheCristall.txt");
            DS.MesOpen(fileLines, fileLines[0], 1, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 2, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 3, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesExit();
            GM.youCanAct = true;
            D1S.triggerDialoge[1] = true;
            WTD = 0;
        }
    }

    public void Dialog5()
    {
        if (WTD == 0 && !D1S.triggerDialoge[2])
        {
            GM.youCanAct = false;
            d = Dialog5;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\TheTree.txt");
            DS.MesOpen(fileLines, fileLines[0], 1, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 2, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 3, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesPrint(fileLines, fileLines[0], 4, 0.03f, true);
            WTD = 4;
        }
        else if (WTD == 4)
        {
            DS.MesPrint(fileLines, fileLines[0], 5, 0.03f, true);
            WTD = 5;
        }
        else if (WTD == 5)
        {
            DS.MesPrint(fileLines, fileLines[0], 6, 0.03f, true);
            stateDrivenCameraAnim.SetTrigger("DC2");
            WTD = 6;
        }
        else if (WTD == 6)
        {
            DS.MesPrint(fileLines, fileLines[0], 7, 0.03f, true);
            WTD = 7;
        }
        else if (WTD == 7)
        {
            stateDrivenCameraAnim.SetTrigger("MC");
            DS.MesExit();
            GM.youCanAct = true;
            D1S.triggerDialoge[2] = true;
            WTD = 0;
        }
    }

    public void ParcurZoneDialog1()
    {
        if (WTD == 0 && !D1S.triggerDialoge[3])
        {
            DS.YouCanCont = false;
            GM.youCanAct = false;
            d = ParcurZoneDialog1;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\ParcurAndKeys.txt");
            DS.MesOpen(fileLines, fileLines[0], 1, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 2, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 3, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesExit();
            GM.youCanAct = true;
            D1S.triggerDialoge[3] = true;
            WTD = 0;
        }
    }
    public void ParcurZoneDialog2()
    {
        if (WTD == 0 && !D1S.triggerDialoge[4])
        {
            DS.YouCanCont = false;
            GM.youCanAct = false;
            d = ParcurZoneDialog2;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\ParcurAndKeys.txt");
            DS.MesOpen(fileLines, fileLines[0], 5, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 6, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 7, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesPrint(fileLines, fileLines[0], 8, 0.03f, true);
            WTD = 4;
        }
        else if (WTD == 4)
        {
            DS.MesExit();
            GM.youCanAct = true;
            D1S.triggerDialoge[4] = true;
            WTD = 0;
        }
    }

    public void FirstUpKey()
    {
        if (WTD == 0)
        {
            DS.YouCanCont = false;
            GM.youCanAct = false;
            d = FirstUpKey;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\ParcurAndKeys.txt");
            DS.MesOpen(fileLines, fileLines[0], 12, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 13, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesPrint(fileLines, fileLines[0], 14, 0.03f, true);
            WTD = 3;
        }
        else if (WTD == 3)
        {
            DS.MesPrint(fileLines, fileLines[0], 15, 0.03f, true);
            WTD = 4;
        }
        else if (WTD == 4)
        {
            DS.MesPrint(fileLines, fileLines[0], 16, 0.03f, true);
            WTD = 5;
        }
        else if (WTD == 5)
        {
            DS.MesExit();
            GM.youCanAct = true;
            WTD = 0;
        }
    }
    public void FirstUpKey2()
    {
        if (WTD == 0)
        {
            DS.YouCanCont = false;
            GM.youCanAct = false;
            d = FirstUpKey2;
            fileLines = DS.DraftingАProposal(@"Dialogues\D1\ParcurAndKeys.txt");
            DS.MesOpen(fileLines, fileLines[0], 18, 0.03f);
            WTD = 1;
        }
        else if (WTD == 1)
        {
            DS.MesPrint(fileLines, fileLines[0], 19, 0.03f, true);
            WTD = 2;
        }
        else if (WTD == 2)
        {
            DS.MesExit();
            GM.youCanAct = true;
            WTD = 0;
        }
    }


}
