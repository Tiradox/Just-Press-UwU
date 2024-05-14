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
    [SerializeField] private Transform _translationScreenButtonsParent;
    [SerializeField] private GameObject _translationScreenButtonPrefab;
    [SerializeField] private TMP_FontAsset _unicFont;
    [SerializeField] private TMP_FontAsset _defoultSmallFont;
    private List<LocalizationTextData> _localizationTopTextData;

    [Header("Attention panel")]
    [SerializeField] private GameObject _attentionPanel;
    [SerializeField] private TMP_Text _attentionPanelTopText;
    [SerializeField] private TMP_Text _attentionPanelDescroptionText;
    [SerializeField] private IntroButton _attentionPanelNextButton;

    [Space]
    [SerializeField] private GameObject _bgLines;

    [Space]
    [Header("Audio")]
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _loadAS;
    [SerializeField] private AudioSource _bipAS;

    private bool _uCan = true;

    private void Start()
    {
        if (SettingsSaveManager.settingsSave != null && SettingsSaveManager.settingsSave.GameStage > 0)
        {
            LocalizationManager.SetLocalization(SettingsSaveManager.settingsSave.LanguageCode);

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
        _mainMusic.Play();

        _localizationTopTextData = new List<LocalizationTextData>();
        LocalizationTextData localizationTextData;
        localizationTextData.Font = _unicFont;
        localizationTextData.Text = "Language";
        _localizationTopTextData.Add(localizationTextData);
        _localizationTopTextData.AddRange(LocalizationManager.GetLocalizationsButtonsDatas("Default"));

        string[] localizationCodes = LocalizationManager.GetLocalizationsCodes();

        for (int i = 0; i < localizationCodes.Length; i++)
        {
            IntroButton button = Instantiate(_translationScreenButtonPrefab, _translationScreenButtonsParent).GetComponent<IntroButton>();
            button.SetData(localizationCodes[i], _defoultSmallFont, SetLocalization);
        }

        StartCoroutine(CycleOfTheTopTextOfTheTranslationScreen());
    }

    private void LoadSettings()
    {
        if(SettingsSaveManager.settingsSave.GameStage == 1)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (SettingsSaveManager.settingsSave.GameStage == 2)
        {
            SceneManager.LoadScene("IntRL");
        }
        else if (SettingsSaveManager.settingsSave.GameStage == 3)
        {
            SceneManager.LoadScene("PlayerReborn");
        }
        else if (SettingsSaveManager.settingsSave.GameStage == 99)
        {
            SceneManager.LoadScene("Omega waiting room");
        }
    }

    private IEnumerator CycleOfTheTopTextOfTheTranslationScreen()
    {
        int i = 0;

        while(true)
        {
            _theTopTextOfTheTranslationScreen.font = _localizationTopTextData[i].Font;
            _theTopTextOfTheTranslationScreen.text = _localizationTopTextData[i].Text;

            i++;
            if (i >= _localizationTopTextData.Count)
            {
                i = 0;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Attention()
    {
        yield return new WaitForSeconds(0.1f);
        _languageSelectPanel.SetActive(false);
        _attentionPanel.SetActive(true);

        string[] attentionPanelDescroption = LocalizationManager.GetText("AttentionPanelDescroption").Split('&');
        _attentionPanelDescroptionText.font = LocalizationManager.GetFont("Small");
        _attentionPanelTopText.font = LocalizationManager.GetFont("Default");
        _attentionPanelTopText.text = LocalizationManager.GetText("AttentionPanelTopText");

        WaitForSeconds wrightWheit = new WaitForSeconds(0.005f);
        for (int i = 0; i != attentionPanelDescroption[0].Length; i++)
        {
            _attentionPanelDescroptionText.text += attentionPanelDescroption[0][i];
            yield return wrightWheit;
        }

        yield return new WaitForSeconds(1f);
        for (int i = 1; i < attentionPanelDescroption.Length; i++)
        {
            _attentionPanelDescroptionText.text += attentionPanelDescroption[i];
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1f);
        _attentionPanelNextButton.SetData(LocalizationManager.GetText("AttentionPanelButtonText"), LocalizationManager.GetFont("Small"), OnAttentionPanelButtonDown);
    }
    public void OnAttentionPanelButtonDown(string s)
    {
        _mainMusic.Stop();
        _bipAS.Play();

        StartCoroutine(Exit());
    }
    private IEnumerator Exit()
    {
        _bgLines.SetActive(false);
        _attentionPanel.SetActive(false);
        yield return new WaitForSeconds(2f);
        SettingsSaveManager.settingsSave.GameStage = 1;

        SceneManager.LoadScene("SampleScene");
    }
    public void SetLocalization(string localizationCode)
    {
        if(!_uCan)
        {
            return;
        }
        _uCan = false;

        SettingsSaveManager.settingsSave.LanguageCode = localizationCode;
        LocalizationManager.SetLocalization(SettingsSaveManager.settingsSave.LanguageCode);
        StartCoroutine(Attention());
        _bipAS.Play();
    }
}
