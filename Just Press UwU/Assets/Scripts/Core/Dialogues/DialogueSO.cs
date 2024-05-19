using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New dialogue", menuName = "Create Dialogue", order = 0)]
public class DialogueSO : ScriptableObject
{
    [Space]
    [SerializeField] private DialogueLine[] _dialogueLines;
    [SerializeField] private DialogueButtonInfo[] _dialogueButtons;
    [SerializeField] private bool _closeDialogueWindow = true;

    public DialogueLine[] GetDialogueLines()
    {
        return _dialogueLines;
    }
    public bool ThisIsFinalDailogue(int i)
    {
        if(i == _dialogueLines.Length - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DialogueButtonInfo[] GetButtons()
    {
        return _dialogueButtons;
    }
    public bool GetCloseDialogueWindow()
    {
        return _closeDialogueWindow;
    }
}

[Serializable]
public class DialogueLine
{
    [SerializeField] private Sprite _dialodueSprite;
    [SerializeField] private string _autor;
    [SerializeField] private string _autorFont = "Default";
    [TextArea] [SerializeField] private string _text;
    [SerializeField] private string _font = "Default";
    [SerializeField] private AudioClip _sound;
    [Space]
    [SerializeField] private bool _auto = false;
    [SerializeField] private float _delay = 1f;
    [Space]
    [SerializeField] private string _metod;

    public Sprite GetSprite()
    {
        return _dialodueSprite;
    }
    public string GetAutor()
    {
        return _autor;
    }
    public string GetAutorFont()
    {
        return _autorFont;
    }
    public string GetText()
    {
        return _text;
    }
    public string GetFont()
    {
        return _font;
    }
    public AudioClip GetSound()
    {
        return _sound;
    }
    public string GetMetod()
    {
        return _metod;
    }
    public bool IsAuto()
    {
        return _auto;
    }
    public float GetDelay()
    {
        return _delay;
    }
}

[Serializable]
public class DialogueButtonInfo
{
    [SerializeField] private string _text;
    [SerializeField] private DialogueSO _dialog;

    [Space]
    [SerializeField] private string _metod;
    [SerializeField] private bool _unstanPlayer = true;

    public string GetText()
    {
        return _text;
    }
    public DialogueSO GetDialog()
    {
        return _dialog;
    }
    public string GetMetod()
    {
        return _metod;
    }
    public bool GetUnstanPlayer()
    {
        return _unstanPlayer;
    }
}
