using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CopyButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Text _text;

    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _anim.SetTrigger("Enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _anim.SetTrigger("Exit");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _anim.SetTrigger("Down");
        _text.text.CopyToClipboard();
    }
}
