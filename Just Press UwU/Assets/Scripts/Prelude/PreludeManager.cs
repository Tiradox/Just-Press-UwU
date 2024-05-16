using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PreludeManager : MonoBehaviour
{
    [Header("Windows")]
    public GameObject imPlayer;

    [Space]
    [Header("Rest")]
    public DialogueSystem DS;
    public Animator BAnim;
    public Animator CamAin;
    public AudioSource MainMusic;
    public AudioSource AUButton;
    public AudioSource AUZ3;
    public AudioSource AUZ4;
    public AudioSource AUZ6_2;
    public AudioSource AUZ7_1;
    public AudioSource AUZ7_2;
    public AudioSource Glitsh;
    public PlayableDirector Cat1;
    public GameObject Dirt;
    public Animator RebutAnim;
    public GameObject RebutSpark;

    private int WTD = 0;
    protected string[] _rootFileText;

    [Space]

    public PlayableDirector CatFin;

    public void Start()
    {
        StartCoroutine(Mbutton());
    }

    public void BTrigger()
    {
        if (GameManager.uCan && WTD!=3)
        {
            StartCoroutine(Mbutton());
            BAnim.SetTrigger("Click");
            AUButton.Play();
        }
        else if (GameManager.uCan && WTD == 3)
        {
            BAnim.SetTrigger("Click2");
            AUButton.Play();
            //fileLines2 = DS.DraftingАProposalRoot("root_files/not identified 2/4787/[ root file 1 ].txt");
            if (_rootFileText[5] == "pix 5 [ reboot ] - on" && _rootFileText[11] == ">MagicImergentiv3310")
            {
                CatFin.Play();
                SettingsSaveManager.settingsSave.GameStage = 2;
            }
        }
    }

    public IEnumerator Mbutton()
    {
        //fileLines = DS.DraftingАProposal("Dialogues/Lm/Dialog1.txt");

        if (WTD == 0)
        {
            MainMusic.volume = 0f;
            GameManager.uCan = false;

            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[0]);
            //DS.PrintTxt(fileLines, 0, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 0, imPlayer, 0.03f, true));
            WTD = 1;
        }
        else if (WTD == 1)
        {
            GameManager.uCan = false;

            //DS.DESTROYTxt(fileLines, 0, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[1 * 3]);
            //DS.PrintTxt(fileLines, 1, imPlayer);
            yield return new WaitForSeconds(3f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 1, imPlayer, 0.5f, false));

            yield return new WaitForSeconds(3f);
            //DS.DESTROYTxt(fileLines, 1, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[2 * 3]);
            //DS.PrintTxt(fileLines, 2, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 2, imPlayer, 0.1f, false));

            yield return new WaitForSeconds(3f);
            //DS.DESTROYTxt(fileLines, 2, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[3 * 3]);
            //DS.PrintTxt(fileLines, 3, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 3, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(2.5f);
            //DS.DESTROYTxt(fileLines, 3, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[4 * 3]);
            //DS.PrintTxt(fileLines, 4, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 4, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(2.5f);
            //DS.DESTROYTxt(fileLines, 4, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[5 * 3]);
            // DS.PrintTxt(fileLines, 5, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 5, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(2.5f);
            //DS.DESTROYTxt(fileLines, 5, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[6 * 3]);
            //DS.PrintTxt(fileLines, 6, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 6, imPlayer, 0.1f, false));

            yield return new WaitForSeconds(2.5f);
            //DS.DESTROYTxt(fileLines, 6, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[7 * 3]);
            //DS.PrintTxt(fileLines, 7, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 7, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(2.5f);
            //DS.DESTROYTxt(fileLines, 7, imPlayer);
            yield return new WaitForSeconds(0.5f);
            BAnim.SetTrigger("Res");
            CamAin.SetTrigger("Sh1");
            Glitsh.Play();
            yield return new WaitForSeconds(2.2f);
            AUZ4.Play();

            yield return new WaitForSeconds(1f);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[8 * 3]);
            //DS.PrintTxt(fileLines, 8, imPlayer);
            yield return new WaitForSeconds(2f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 8, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(2f);
            //DS.DESTROYTxt(fileLines, 8, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[9 * 3]);
            //DS.PrintTxt(fileLines, 9, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 9, imPlayer, 0.1f, false));

            yield return new WaitForSeconds(1.5f);
            //DS.DESTROYTxt(fileLines, 9, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[10 * 3]) + int.Parse(fileLines[11 * 3]);
            //DS.PrintTxt(fileLines, 10, imPlayer);
            //DS.PrintTxt(fileLines, 11, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 10, imPlayer, 0.05f, false));
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 11, imPlayer, 0.05f, int.Parse(fileLines[10 * 3]), false));

            yield return new WaitForSeconds(2f);
            //DS.DESTROYTxt(fileLines, 10, imPlayer, 11);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[12 * 3]);
            //DS.PrintTxt(fileLines, 12, imPlayer);
            yield return new WaitForSeconds(2f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 12, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(1.5f);
            //DS.DESTROYTxt(fileLines, 12, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[13 * 3]);
            //DS.PrintTxt(fileLines, 13, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 13, imPlayer, 0.05f, true));

            WTD = 2;
        }
        else if (WTD == 2)
        {
            GameManager.uCan = false;
            Cat1.Play();
            //DS.DESTROYTxt(fileLines, 13, imPlayer);

            yield return new WaitForSeconds(5.02f);
            Dirt.SetActive(true);
            BAnim.SetTrigger("Dirt");
            RebutAnim.SetTrigger("Down");
            yield return new WaitForSeconds(0.5f);

            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[14 * 3]);
            //DS.PrintTxt(fileLines, 14, imPlayer);
            //StartCoroutine(DS.TxtAnimation(fileLines, 14, imPlayer, 0.03f, false));

            yield return new WaitForSeconds(1.5f);
            //DS.DESTROYTxt(fileLines, 14, imPlayer);
            // imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[15 * 3]);
            // DS.PrintTxt(fileLines, 15, imPlayer);
            yield return new WaitForSeconds(0.6f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 15, imPlayer, 0.03f, false));

            yield return new WaitForSeconds(1.6f);
            //DS.DESTROYTxt(fileLines, 15, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[16 * 3]);
            // DS.PrintTxt(fileLines, 16, imPlayer);
            yield return new WaitForSeconds(0.6f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 16, imPlayer, 0.05f, false));
            CamAin.SetTrigger("0m");

            yield return new WaitForSeconds(2f);
            //DS.DESTROYTxt(fileLines, 16, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[17 * 3]) + int.Parse(fileLines[18 * 3]);
            //DS.PrintTxt(fileLines, 17, imPlayer);
            //DS.PrintTxt(fileLines, 18, imPlayer);
            yield return new WaitForSeconds(1f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 17, imPlayer, 0.1f, false));
            yield return new WaitForSeconds(0.6f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 18, imPlayer, 0.03f, int.Parse(fileLines[17 * 3]), false));

            yield return new WaitForSeconds(3f);
            //DS.DESTROYTxt(fileLines, 17, imPlayer, 18);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[19 * 3]);
            //DS.PrintTxt(fileLines, 19, imPlayer);
            yield return new WaitForSeconds(0.6f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 19, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(1.5f);
            //DS.DESTROYTxt(fileLines, 19, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[20 * 3]);
            //DS.PrintTxt(fileLines, 20, imPlayer);
            yield return new WaitForSeconds(0.6f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 20, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(1.5f);
            //DS.DESTROYTxt(fileLines, 20, imPlayer);
            //imPlayer.GetComponent<GridLayoutGroup>().constraintCount = int.Parse(fileLines[21 * 3]);
            //DS.PrintTxt(fileLines, 21, imPlayer);
            yield return new WaitForSeconds(0.6f);
            //StartCoroutine(DS.TxtAnimation(fileLines, 21, imPlayer, 0.05f, false));

            yield return new WaitForSeconds(1.5f);
            //DS.DESTROYTxt(fileLines, 21, imPlayer);
            AUZ7_1.Play();
            yield return new WaitForSeconds(7f);
            AUZ7_2.Play();
            yield return new WaitForSeconds(2f);
            CamAin.SetTrigger("Run");
            yield return new WaitForSeconds(0.35f);
            WTD = 3;
            GameManager.uCan = true;
        }
    }
}
