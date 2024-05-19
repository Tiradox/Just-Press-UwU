using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using Tiradox;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager singelton = null;

    [SerializeField] private TMP_Text _autor;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _ava;
    [SerializeField] private GameObject _outline;
    [SerializeField] private GameObject _arrowObj;
    [SerializeField] private Transform _buttonsParent;
    [SerializeField] private GameObject _buttonPrefub;

    [Space]
    [SerializeField] private Sprite _defoultAva;
    [SerializeField] private Sprite _nullAva;
    private Animator _animator;

    private bool _dialogOutputFinished = false;
    private bool _itsButtonTime = false;
    private bool _dialogueIsEnd = false;

    private int _selectedButton = 0;

    private DialogueVertexAnimator dialogueVertexAnimator = null;

    private DialogueSO dialogueSO;

    private int thisDialogue;
    private Object _triggerObject;

    private bool _dialogueWindowIsOpen = false;

    private void Awake()
    {
        singelton = this;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (dialogueVertexAnimator == null) return;
        if (dialogueSO == null) return;
        if (dialogueSO.GetDialogueLines()[thisDialogue].IsAuto()) return;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && _dialogOutputFinished && !_dialogueIsEnd && !_itsButtonTime)
        {
            _arrowObj?.SetActive(false);
            NextDialogueOutput();
        }
        else if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && !_dialogOutputFinished && !_dialogueIsEnd && !_itsButtonTime)
        {
            SkipToEndOfCurrentMessage();
        }
    }

    public void StartDialogue(DialogueSO dSO, Object triggerObject)
    {
        thisDialogue = 0;
        dialogueSO = dSO;
        _triggerObject = triggerObject;
        _dialogOutputFinished = false;
        _dialogueIsEnd = false;
        _itsButtonTime = false;
        _selectedButton = 0;
        if(_arrowObj)
        {
            _arrowObj.SetActive(false);
        }

        dialogueVertexAnimator = new DialogueVertexAnimator(_text);
        if (dialogueVertexAnimator != null)
        {
            ClearText();
        }

        SetAva(dialogueSO.GetDialogueLines()[thisDialogue]);
        if(_autor != null)
        {
            if (!string.IsNullOrEmpty(dialogueSO.GetDialogueLines()[thisDialogue].GetAutor()))
            {
                _autor.text = LocalizationManager.GetText(dialogueSO.GetDialogueLines()[thisDialogue].GetAutor());
                _autor.font = LocalizationManager.GetFont(dialogueSO.GetDialogueLines()[thisDialogue].GetAutorFont());
            }
            else
            {
                _autor.text = "";
            }
        }
        if(_animator && !_dialogueWindowIsOpen)
        {
            _animator.SetTrigger("Act");
            _dialogueWindowIsOpen = true;
        }
        else
        {
            PlayDialogueAfterAnim();
        }
    }
    public void ContinueDialogue(DialogueSO dSO)
    {
        if(dSO != null)
        {
            thisDialogue = 0;
            dialogueSO = dSO;
            _dialogOutputFinished = false;
            _itsButtonTime = false;
            _selectedButton = 0;
            PlayDialogue(dialogueSO.GetDialogueLines()[0]);
        }
        else
        {
            EndDialogue();
        }
    }
    private void EndDialogue()
    {
        dialogueVertexAnimator = null;
        _dialogueIsEnd = true;
        if (_animator && dialogueSO.GetCloseDialogueWindow())
        {
            _animator.SetTrigger("DisAct");
            _dialogueWindowIsOpen = false;
        }

        if(dialogueSO.GetButtons().Length > 0)
        {
            if (dialogueSO.GetButtons()[_selectedButton].GetUnstanPlayer())
            {
                //FindFirstObjectByType<HeroController>().stan = false;
            }
        }
        else
        {
            //FindFirstObjectByType<HeroController>().stan = false;
        }
    }

    private void SkipToEndOfCurrentMessage()
    {
        dialogueVertexAnimator.SkipToEndOfCurrentMessage();
    }
    private void NextDialogueOutput()
    {
        InvokeFunction(dialogueSO.GetDialogueLines()[thisDialogue].GetMetod());

        if (!dialogueSO.ThisIsFinalDailogue(thisDialogue))
        {
            thisDialogue++;
            _dialogOutputFinished = false;

            PlayDialogue(dialogueSO.GetDialogueLines()[thisDialogue]);
        }
        else
        {
            if(dialogueSO.GetButtons().Length == 1)
            {
                ContinueDialogue(dialogueSO.GetButtons()[0].GetDialog());
            }
            else
            {
                EndDialogue();
            }
        }
    }
    private void PlayDialogue(DialogueLine dialogueLine)
    {
        SetAva(dialogueLine);
        if (!string.IsNullOrEmpty(dialogueLine.GetAutor()))
        {
            if(_autor)
            {
                _autor.text = LocalizationManager.GetText(dialogueLine.GetAutor());
                _autor.font = LocalizationManager.GetFont(dialogueLine.GetAutorFont());
            }
            OutputString(LocalizationManager.GetText(dialogueLine.GetText()), LocalizationManager.GetFont(dialogueLine.GetFont()));
        }
        else
        {
            if (_autor)
            {
                _autor.text = "";
            }
            OutputString("* " + LocalizationManager.GetText(dialogueLine.GetText()), LocalizationManager.GetFont(dialogueLine.GetFont()));
        }
    }
    private void PlayDialogueAfterAnim()
    {
        if(!string.IsNullOrEmpty(dialogueSO.GetDialogueLines()[thisDialogue].GetAutor()))
        {
            OutputString(LocalizationManager.GetText(dialogueSO.GetDialogueLines()[thisDialogue].GetText()), LocalizationManager.GetFont(dialogueSO.GetDialogueLines()[thisDialogue].GetFont()));
        }
        else
        {
            OutputString("* " + LocalizationManager.GetText(dialogueSO.GetDialogueLines()[thisDialogue].GetText()), LocalizationManager.GetFont(dialogueSO.GetDialogueLines()[thisDialogue].GetFont()));
        }
    }
    private void SetAva(DialogueLine dialogueLine)
    {
        if (_ava == null) return;

        if (dialogueLine.GetSprite() != null)
        {
            _outline.SetActive(true);
            _ava.sprite = dialogueLine.GetSprite();
        }
        else
        {
            if (string.IsNullOrEmpty(dialogueLine.GetAutor()))
            {
                _outline.SetActive(false);
                _ava.sprite = _nullAva;
            }
            else
            {
                _outline.SetActive(true);
                _ava.sprite = _defoultAva;
            }
        }
    }
    private void DialogueOutPutWasFinished()
    {
        if (dialogueSO.GetButtons().Length <= 1)
        {
            if(dialogueSO.GetDialogueLines()[thisDialogue].IsAuto())
            {
                StartCoroutine(StartNextDialodueDelay(dialogueSO.GetDialogueLines()[thisDialogue].GetDelay()));
                return;
            }
            _arrowObj?.SetActive(true);
        }
        else
        {
            if(dialogueSO.ThisIsFinalDailogue(thisDialogue))
            {
                _itsButtonTime = true;
                SpawnButtons();
            }
            else
            {
                if (dialogueSO.GetDialogueLines()[thisDialogue].IsAuto())
                {
                    StartCoroutine(StartNextDialodueDelay(dialogueSO.GetDialogueLines()[thisDialogue].GetDelay()));
                    return;
                }
                _arrowObj?.SetActive(true);
            }
        }

        _dialogOutputFinished = true;
    }
    private IEnumerator StartNextDialodueDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        NextDialogueOutput();
    }
    private void InvokeFunction(string nameOfFunction)
    {
        if (string.IsNullOrEmpty(nameOfFunction)) return;

        MethodInfo method = _triggerObject.GetType().GetMethod(nameOfFunction);
        method.Invoke(_triggerObject, null);
    }
    public void OnDialodueButtonDown(int num)
    {
        DestroyButtons(num);

        _selectedButton = num;

        if (!string.IsNullOrEmpty(dialogueSO.GetButtons()[num].GetMetod()))
        {
            InvokeFunction(dialogueSO.GetButtons()[num].GetMetod());
        }
    }
    public void StartButtonDialogue(int num)
    {
        ContinueDialogue(dialogueSO.GetButtons()[num].GetDialog());
    }
    private void SpawnButtons()
    {
        for (int i = 0; i < dialogueSO.GetButtons().Length; i++)
        {
            DialogueButton button = Instantiate(_buttonPrefub, _buttonsParent).GetComponent<DialogueButton>();
            button.SetData(i, LocalizationManager.GetText(dialogueSO.GetButtons()[i].GetText()));
        }

        LayoutGroupsRefresher.Refresh(_buttonsParent.gameObject);
    }
    private void DestroyButtons(int num)
    {
        for (int i = 0; i < _buttonsParent.childCount; i++)
        {
            if(num != i)
            {
                Destroy(_buttonsParent.GetChild(i).gameObject);
            }
        }
    }

    private Coroutine typeRoutine = null;
    private void OutputString(string message, TMP_FontAsset font)
    {
        StopAllCoroutines();
        dialogueVertexAnimator.textAnimating = false;

        _text.font = font;

        List<DialogueCommand> commands = DialogueUtility.ProcessInputString(message, out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, () =>
        {
            DialogueOutPutWasFinished();
        }));
    }
    private void ClearText()
    {
        StopAllCoroutines();
        dialogueVertexAnimator.textAnimating = false;
        List<DialogueCommand> commands = DialogueUtility.ProcessInputString("", out string totalTextMessage);
        typeRoutine = StartCoroutine(dialogueVertexAnimator.AnimateTextIn(commands, totalTextMessage, null));
    }
}
