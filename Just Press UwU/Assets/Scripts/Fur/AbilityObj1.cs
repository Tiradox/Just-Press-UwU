using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityObj1 : MonoBehaviour
{
    public AudioSource Au;
    private GameObject Player;
    public int Ab;
    public GameUiManager GUM;
    public Animation anim;
    public TheChatDialog TCD;

    private void Start()
    {
        GlobalEventManager.OnAbilityLoadad += AbilityInst;
    }
    private void OnDisable()
    {
        GlobalEventManager.OnAbilityLoadad -= AbilityInst;
    }
    private void AbilityInst()
    {
        Player = GameObject.Find("- Player -(Clone)");

        if(Player.GetComponent<PlayerSet>().аbility[Ab])
        {
            gameObject.SetActive(false);
        }
    }
    public void TakeIt()
    {
        TCD.AbTakeDialoge();
        Au.Play();
        Player.GetComponent<PlayerSet>().аbility[Ab] = true;
        GUM.SetAb();
        anim.Play();
        gameObject.SetActive(false);
    }
}
