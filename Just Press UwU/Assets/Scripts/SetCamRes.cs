using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamRes : MonoBehaviour
{
    void Awake()
    {
        Resolution[] resolutions = Screen.resolutions;

        foreach (var res in resolutions)
        {
            Screen.SetResolution(res.height, res.height, true);
        }
    }

    private IEnumerator ie()
    {
        yield return new WaitForSeconds(4f);

        Resolution[] resolutions = Screen.resolutions;
        foreach (var res in resolutions)
        {
            Screen.SetResolution(res.height, res.height, true);
        }
    }
}
