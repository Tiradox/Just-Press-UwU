using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _hiddenText;

    private Animator _anim;
    private int _num;
    private bool _onDown = false;

    public void SetData(int num, string text)
    {
        _num = num;
        _hiddenText.text = text;
        _text.text = text;
        _anim = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_onDown) return;
        _anim.SetTrigger("Enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_onDown) return;
        _anim.SetTrigger("Exit");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_onDown) return;
        _onDown = true;
        DialogueManager.singelton.OnDialodueButtonDown(_num);
        _anim.SetTrigger("Down");
    }

    private void AnimEnd()
    {
        DialogueManager.singelton.StartButtonDialogue(_num);
        Destroy(gameObject);
    }
}
