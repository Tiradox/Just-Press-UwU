using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionObject : MonoBehaviour
{
    public UnityEvent Act;
    public GameObject IntImg;
    public void ActivateInt()
    {
        Act.Invoke();
    }
    public void IntImgOn()
    {
        IntImg.SetActive(true);
    }
    public void IntImgOff()
    {
        IntImg.SetActive(false);
    }
}
