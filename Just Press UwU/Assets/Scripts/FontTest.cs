using UnityEngine;
using TMPro;
using Tiradox;

public class FontTest : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void LoadLocalization()
    {
        LocalizationManager.SetLocalization("RUS");

        _text.font = LocalizationManager.GetFont("Small");
        _text.text = LocalizationManager.GetText("TestText");
    }
}
