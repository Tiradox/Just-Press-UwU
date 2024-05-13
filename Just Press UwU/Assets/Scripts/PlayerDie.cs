using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public AudioSource Au;
    public void DaIgrocUmer()
    {
        StartCoroutine(IeDie());
    }

    private IEnumerator IeDie()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("RL1");
    }

    public void DaIgrocUmer0()
    {
        Au.mute = true;
    }
}
