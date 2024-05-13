using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Tiradox;

public class GameIntroManager : MonoBehaviour
{
    [Header("Loading Panel")]
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private TMP_Text _loadingText;
    [SerializeField] private Animator _fillAniamtor;

    [Header("Language Select panel")]
    [SerializeField] private GameObject _languageSelectPanel;
    [SerializeField] private TMP_Text _theTopTextOfTheTranslationScreen;
    [SerializeField] private TMP_FontAsset Font1;
    [SerializeField] private TMP_FontAsset Font2;

    [Header("Attention panel")]
    [SerializeField] private GameObject _attentionPanel;

    [Space]
    [SerializeField] private GameObject _bgLines;

    [Space]
    [Header("Audio")]
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _loadAS;
    [SerializeField] private AudioSource _bipAS;

    private string _localizationPath;
    private List<string> fileLines;

    private bool _uCan = true;

    private void Start()
    {
        if (SettingsSaveManager.settingsSave != null && SettingsSaveManager.settingsSave.gameStage > 0)
        {
            LoadSettings();
        }
        else
        {
            StartCoroutine(StartNewGame());
        }
    }

    private IEnumerator StartNewGame()
    {
        _loadingPanel.SetActive(true);
        _loadAS.Play();
        _fillAniamtor.SetTrigger("Act");
        yield return new WaitForSeconds(4.2f);
        StartCoroutine(StartNewGameGeneralExpectation());
        _loadingText.text = "[";
        yield return new WaitForSeconds(1f);
        _loadingText.text = "[#";
        yield return new WaitForSeconds(0.3f);
        _loadingText.text = "[##";
        yield return new WaitForSeconds(0.2f);
        _loadingText.text = "[###";
        yield return new WaitForSeconds(0.3f);
        _loadingText.text = "[####";
        yield return new WaitForSeconds(0.1f);
        _loadingText.text = "[#####";
        yield return new WaitForSeconds(1.8f);
        _loadingText.text = "[######";
        yield return new WaitForSeconds(0.4f);
        _loadingText.text = "[######]";
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator StartNewGameGeneralExpectation()
    {
        yield return new WaitForSeconds(13f);
        _loadingPanel.SetActive(false);
        _bgLines.SetActive(true);
        _languageSelectPanel.SetActive(true);
        StartCoroutine(CycleOfTheTopTextOfTheTranslationScreen());
        _mainMusic.Play();
    }

    private void LoadSettings()
    {
        if(SettingsSaveManager.settingsSave.gameStage == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (SettingsSaveManager.settingsSave.gameStage == 2)
        {
            SceneManager.LoadScene("IntRL");
        }
        else if (SettingsSaveManager.settingsSave.gameStage == 3)
        {
            SceneManager.LoadScene("PlayerReborn");
        }
        else if (SettingsSaveManager.settingsSave.gameStage == 99)
        {
            SceneManager.LoadScene("Omega waiting room");
        }
    }

    private IEnumerator Exit()
    {
        //Blaek.SetActive(true);
        yield return new WaitForSeconds(2f);
        SettingsSaveManager.settingsSave.gameStage = 1;

        SceneManager.LoadScene("SampleScene");
    }

    private IEnumerator CycleOfTheTopTextOfTheTranslationScreen()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            _theTopTextOfTheTranslationScreen.text = "Язык";
            yield return new WaitForSeconds(1f);
            _theTopTextOfTheTranslationScreen.font = Font2;
            _theTopTextOfTheTranslationScreen.text = "Language";
            yield return new WaitForSeconds(1f);
            _theTopTextOfTheTranslationScreen.font = Font1;
            _theTopTextOfTheTranslationScreen.text = "Мова";
            yield return new WaitForSeconds(1f);
            _theTopTextOfTheTranslationScreen.text = "Language";
        }
    }

    private IEnumerator Attention()
    {
        yield return new WaitForSeconds(0.1f);
        _languageSelectPanel.SetActive(false);
        _attentionPanel.SetActive(true);


        for (int i = 0; i != fileLines[1].Length; i++)
        {
            //DesTex.text += fileLines[1][i];
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);
        //DesTex.text += "\n" + fileLines[2];
        yield return new WaitForSeconds(0.2f);
        //DesTex.text += "\n" + fileLines[3];
        yield return new WaitForSeconds(0.2f);
        //DesTex.text += "\n" + fileLines[4] + "\n\n";

        for (int i = 0; i != fileLines[5].Length; i++)
        {
            //DesTex.text += fileLines[5][i];
            yield return new WaitForSeconds(0.01f);
        }

        //ButtonTex.text = fileLines[6];
        _uCan = true;
    }
    public void AEn()
    {
        //ButtonTex.text =  "> " + fileLines[6];
    }
    public void AEx()
    {
        //ButtonTex.text = fileLines[6];
    }
    public void Ap()
    {
        _mainMusic.Stop();
        //bi.Play();

        StartCoroutine(Exit());
    }

    public void SetLocalization(string localizationCode)
    {
        if(!_uCan)
        {
            return;
        }
        _uCan = false;

        SettingsSaveManager.settingsSave.language = localizationCode;
        _localizationPath = Application.streamingAssetsPath + "/Localizations/" + SettingsSaveManager.settingsSave.language + "/UI/Settings.txt";
        fileLines = File.ReadAllLines(_localizationPath).ToList();
        StartCoroutine(Attention());
        _bipAS.Play();
    }
}
