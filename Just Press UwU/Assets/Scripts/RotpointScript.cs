using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotpointScript : MonoBehaviour
{
    public bool IsRotate = false;
    private Transform Player;
    public float OffSet;
    public float Rot;

    private void Start()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }

    private void PlayerInst()
    {
        Player = GameObject.Find("- Player -(Clone)").transform;
        IsRotate = true;
    }

    private void Update()
    {
        if (IsRotate)
        {
            Vector3 diffense = Player.position - transform.position;
            float rotZ = Mathf.Atan2(diffense.y, diffense.x) * Mathf.Rad2Deg;
            Rot = rotZ;
            transform.rotation = Quaternion.Euler(0f, 0f, Rot + OffSet);
        }
        else if (!IsRotate)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, Rot + OffSet);
        }
    }
}
