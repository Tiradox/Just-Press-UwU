using System.Collections;
using UnityEngine;

public class DubbleJump : MonoBehaviour
{
    private bool isAct;
    private Animator _anim;
    private GameObject lightGameObj;
    private AudioSource au;

    private void Start()
    {
        lightGameObj = transform.Find("Point Light 2D").gameObject;
        _anim = GetComponent<Animator>();
        au = transform.Find("Audio Source").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isAct)
        {
            collision.GetComponent<Collision>().doubleJump = true;
            isAct = true;
            _anim.SetTrigger("Off");
            lightGameObj.SetActive(false);
            StartCoroutine(IeWait());
            au.Play();
        }
    }

    private IEnumerator IeWait()
    {
        yield return new WaitForSeconds(3f);
        isAct = false;
        _anim.SetTrigger("Idle");
        lightGameObj.SetActive(true);
    }
}
