using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntRlManager : MonoBehaviour
{
    public Animator CamAnim;
    public AudioSource Au;
    public bool YAS = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && YAS)
        {
            YAS = false;
            CamAnim.SetTrigger("1");
            Au.Play();
            StartCoroutine(Exit());
        }
    }

    private IEnumerator Exit()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TheFall");
    }

    public void YasOn()
    {
        YAS = true;
    }
}
