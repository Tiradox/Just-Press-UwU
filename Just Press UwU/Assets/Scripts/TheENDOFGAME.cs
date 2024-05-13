using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheENDOFGAME : MonoBehaviour
{
    public Sprite sRu;
    public Sprite sEn;
    public GameManager GM;
    public SpriteRenderer sr;

    private void Start()
    {
        GM.stage = 99;

        if(GM.language == "RU")
        {
            sr.sprite = sRu;
        }
        else if (GM.language == "EN")
        {
            sr.sprite = sEn;
        }

        GM.SaveSettings();
    }
}
