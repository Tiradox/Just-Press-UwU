using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class IntroButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UnityEvent _onButtonDown;

    [Space]
    [SerializeField] private TMP_Text _textField;

    private string _text;

    public void SetData(string text)
    {
        _text = text;
        _textField.text = text;
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
        _onButtonDown.Invoke();
    }
}
