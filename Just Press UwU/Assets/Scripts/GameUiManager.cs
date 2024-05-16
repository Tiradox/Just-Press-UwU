using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiManager : MonoBehaviour
{
    private Animator CanAnim;

    private PlayerMovement PV;
    private PlayerSet PS;

    private Action Spell;

    [Space]
    public Sprite[] HpSprite = new Sprite[7];
    public GameObject HpObject;

    [Space]

    public Animator ChargingBarAnim;
    public AudioSource ChargingBarAU1;
    public AudioSource ChargingBarAU2;
    public AudioSource ChargingBarAU3;
    public bool ThisCharged = false;
    private float ChargeTime = 5f;
    public bool StartCharging = false;

    public GameObject[] Ability = new GameObject[3];
    public Sprite[] AbilitySprite = new Sprite[3];

    [Space]
    public Animator ChoseRingAnim;
    public AudioSource ChoseRingAU;

    [Space]
    public Animator BoostAnim;

    [Space]
    public bool youCanUseIt = true;
    public GameObject blockedText;
    public AudioSource ErrorAu;

    void Awake()
    {
        GlobalEventManager.OnAbilityLoadad += AbilityLoaded;
        CanAnim = GetComponent<Animator>();
        Spell = Dash;
    }

    void Update()
    {
        if (GameManager.uCan)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && ThisCharged && youCanUseIt)
            {
                Spell.Invoke();
            }
            else if(Input.GetKeyDown(KeyCode.LeftShift) && !youCanUseIt)
            {
                StartCoroutine(blTex());
                ErrorAu.Play();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Spell = Dash;
                ChoseRingAnim.SetTrigger("0");
                ChoseRingAU.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Spell = Gun;
                ChoseRingAnim.SetTrigger("1");
                ChoseRingAU.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Spell = Shield;
                ChoseRingAnim.SetTrigger("2");
                ChoseRingAU.Play();
            }

        }

        if (StartCharging && ChargeTime > 0)
        {
            ChargeTime -= Time.deltaTime;
        }
        else if (StartCharging && ChargeTime <= 0)
        {
            StartCharging = false;
            ChargeTime = 5f;
            EndCharging();
        }
        
    }
    private void OnDisable()
    {
        GlobalEventManager.OnAbilityLoadad -= AbilityLoaded;
    }
    public void SetHp(float hel)
    {
        HpObject.GetComponent<Image>().sprite = HpSprite[Convert.ToInt32(hel)];
    }

    private void AbilityLoaded()
    {
        Charge();
        PV = GameObject.Find("- Player -(Clone)").GetComponent<PlayerMovement>();
        PS = GameObject.Find("- Player -(Clone)").GetComponent<PlayerSet>();
        SetAb();
        Debug.Log("Абилки подгружены");
        CanAnim.SetTrigger("On");
        Debug.Log("Включем анимации");
    }

    public void SetAb()
    {
        for (int i = 0; i < PS.аbility.Length; i++)
        {
            if(PS.аbility[i])
            {
                Ability[i].GetComponent<Image>().sprite = AbilitySprite[i];
            }
        }
    }

    private IEnumerator blTex()
    {
        blockedText.SetActive(true);
        yield return new WaitForSeconds(1f);
        blockedText.SetActive(false);
    }

    public void Charge()
    {
        ChargingBarAnim.SetTrigger("Charge");
        ChargingBarAU2.Play();
        StartCharging = true;
    }

    public void UnCharge()
    {
        ChargingBarAnim.SetTrigger("Hollow");
        ThisCharged = false;
        ChargingBarAU3.Play();
    }

    public void EndCharging()
    {
        ThisCharged = true;
        ChargingBarAU1.Play();
    }

    private IEnumerator RepitCharge()
    {
        yield return new WaitForSeconds(0.6f);
        Charge();
    }

    private void Dash()
    {
        if(PV.gameObject.GetComponent<Collision>().onGround && PS.аbility[0])
        {
            PV.Dash();
            UnCharge();
            StartCoroutine(RepitCharge());
            BoostAnim.SetTrigger("Boost");
        }
    }

    private void Gun()
    {
        if (PS.аbility[1])
        {
            PV.Gun();
            UnCharge();
            StartCoroutine(RepitCharge());
        }
    }

    private void Shield()
    {
        if (PS.аbility[2])
        {
            StartCoroutine(PV.Shield());
            UnCharge();
            StartCoroutine(RepitCharge());
        }
    }
}
