using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class ExperimentHoror : MonoBehaviour
{
    void Start()
    {
        PrintScreen();
    }

    private void PrintScreen()
    {
        string path = @"‪C:\Users\79172\AppData\Roaming\Microsoft\Windows\Themes\CachedFiles\image7.jpg";
        string newPath = Application.streamingAssetsPath + @"\image7.jpg";
        FileInfo fileInf = new FileInfo(path);
        fileInf.CopyTo(newPath);
        Debug.Log("УРА!");
    }
}
