using System.IO;
using UnityEngine;

namespace Tiradox
{
    public static class FileHelper
    {
        public static string Read(string path)
        {
            return File.ReadAllText(Application.streamingAssetsPath + path);
        }
        public static string[] ReadLines(string path)
        {
            return File.ReadAllLines(Application.streamingAssetsPath + path);
        }
    }
}
