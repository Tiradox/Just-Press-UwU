using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRaborn : MonoBehaviour
{
    public D1SaveManager D1S;
    void Start()
    {
        SceneManager.LoadScene(D1S.spavnPlaseName);
    }
}
