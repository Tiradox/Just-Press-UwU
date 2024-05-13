using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public string identifier = "0";

    public void ActivationL()
    {
        this.gameObject.GetComponent<Animator>().SetInteger("Rand", Random.Range(0, 2));
        this.gameObject.GetComponent<Animator>().SetTrigger(identifier);
    }
    public IEnumerator Des()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("Des");
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}