using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

public class IntroButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _text;
    [SerializeField] private bool _translated;

    [Space]
    [SerializeField] private UnityEvent _onButtonDown;

    [Space]
    [SerializeField] private TMP_Text _textField;

    private void Awake()
    {
        if (_translated)
        {
            GlobalEventManager.OnLocalizationLoaded += OnLocalizationLoaded;
        }
        else
        {
            _textField.text = _text;
        }
    }

    private void OnDisable()
    {
        if (_translated)
        {
            GlobalEventManager.OnLocalizationLoaded -= OnLocalizationLoaded;
        }
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

    private void OnLocalizationLoaded()
    {
        _text = "???";
        _textField.text = _text;
    }
}
