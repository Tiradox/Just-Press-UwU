using System.Collections;
using UnityEngine;
using TMPro;

public class TheT : MonoBehaviour
{
    public static TheT Chat { get; private set; }

    public TMP_Text chat;
    public AudioSource As;
    private Animator anim;

    private void Start()
    {
        Chat = this;
        anim = GetComponent<Animator>();
    }

    public void SendMes(string s, bool b)
    {
        As.Play();
        StopAllCoroutines();

        chat.text += "\n\n" + s;

        anim.SetTrigger("open");
        if (b) StartCoroutine(closeIE());
    }

    private IEnumerator closeIE()
    {
        yield return new WaitForSeconds(4f);
        anim.SetTrigger("close");
        yield return new WaitForSeconds(4f);
        Clear();
    }

    public void Clear()
    {
        chat.text = "";
    }

}
