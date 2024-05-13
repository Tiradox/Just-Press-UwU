using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ControllerOfShake : MonoBehaviour
{
    public static ControllerOfShake Instance { get; private set; }

    public CinemachineShake[] CS = new CinemachineShake[4];

    private void Awake()
    {
        Instance = this;
    }

    public void InstShakeCamera(float intensity, float time)
    {
        for (int i = 0; i != CS.Length; i++)
        {
            CS[i].ShakeCamera(intensity, time);
        }
    }
}
