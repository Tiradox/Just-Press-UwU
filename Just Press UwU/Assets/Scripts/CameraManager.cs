using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera CVC;

    void OnEnable()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;
    }

    private void PlayerInst()
    {
        CVC.Follow = FindObjectOfType<PlayerMovement>().transform;
    }

    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }
}
