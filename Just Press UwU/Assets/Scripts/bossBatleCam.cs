using UnityEngine;
using Cinemachine;

public class bossBatleCam : MonoBehaviour
{
    private GameObject _player;
    private void Awake()
    {
        GlobalEventManager.OnPlayerInst += PlayerInst;

    }
    private void PlayerInst()
    {
        _player = GameObject.Find("- Player -(Clone)");
    }
    public void BossBattleStart()
    {
        GetComponent<CinemachineVirtualCamera>().Follow = _player.transform;
    }
    private void OnDisable()
    {
        GlobalEventManager.OnPlayerInst -= PlayerInst;
    }
}
