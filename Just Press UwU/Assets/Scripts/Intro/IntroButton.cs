using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class IntroButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Action<string> _onButtonDown;

    [Space]
    [SerializeField] private TMP_Text _textField;

    private string _text;

    public void SetData(string text, TMP_FontAsset fontAsset, Action<string> function)
    {
        _text = text;
        _textField.text = text;
        _textField.font = fontAsset;
        _onButtonDown = function;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _textField.text = $"[   {_text}   ]";
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _textField.text = _text;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _textField.text = $"[{_text}]";
        _onButtonDown.Invoke(_text);
    }
}
