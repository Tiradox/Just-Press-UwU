using System;
using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class PlayerSet : MonoBehaviour
{
    public float health = 6;

    public bool hasGateKey = false;
    public bool[] аbility = new bool[3];
    public bool[] KeyPieces = new bool[2];
    public bool[] SpecificKeyPieces = new bool[2];
    public bool RepEl;
    public bool shieldOn;

    private PlayerSave ds = new PlayerSave();
    string msPath;

    public GameUiManager GUIM;
    public GameObject DiePartSys;
    private PlayerDie PD;
    private Animator DarkCol;

    public Vector2 platformerTp;
    public UnityEvent platformerRestoreEvent;
    private AudioSource au2;
    private AudioSource tdAs;

    public AudioMixer LowPassMixer;
    private float LowPassSpeed = 5000;
    private float LowPassVol = 312;
    private bool lowpass_ON = false;
    public Animation DamageAnim;

    public AudioSource TDau;

    void Awake()
    {
        msPath = Application.streamingAssetsPath + "/PlayerSave.json";

        if (File.Exists(msPath))
        {
            ds = JsonUtility.FromJson<PlayerSave>(File.ReadAllText(msPath));
        }
        else
        {
            File.WriteAllText(msPath, JsonUtility.ToJson(ds));
        }

        LoadSettings();
    }

    private void Start()
    {
        GUIM = GameObject.Find("CanvasUIManager").GetComponent<GameUiManager>();
        PD = GameObject.Find("GameManager").GetComponent<PlayerDie>();
        DarkCol = GameObject.Find("DarkCol").GetComponent<Animator>();
        au2 = transform.Find("Audio Source 2").GetComponent<AudioSource>();
        tdAs = transform.Find("Audio Source Damage").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(lowpass_ON)
        {
            LowPassVol = Mathf.MoveTowards(LowPassVol, 22000, LowPassSpeed * Time.deltaTime);
            if(LowPassVol >= 22000)
            {
                lowpass_ON = false;
                LowPassVol = 22000;
                LowPassMixer.SetFloat("LowPassVol", LowPassVol);
            }
            else
            {
                LowPassMixer.SetFloat("LowPassVol", LowPassVol);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!shieldOn)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                GUIM.SetHp(0);
                Die();
            }
            else
            {
                ControllerOfShake.Instance.InstShakeCamera(4f, 1f);
                GUIM.SetHp(health);
                LowPassMixer.SetFloat("LowPassVol", 312f);
                lowpass_ON = true;
                DamageAnim.Play();
                if (damage >= 3) tdAs.Play();
            }
        }
        else
        {
            TDau.Play();
        }
    }

    public void FullRegen()
    {
        health = 6;
        GUIM.SetHp(health);
    }

    public void Die()
    {
        ControllerOfShake.Instance.InstShakeCamera(8f, 3f);
        PD.DaIgrocUmer0();
        GameManager.uCan = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        Instantiate(DiePartSys, transform.position, transform.rotation);
        gameObject.GetComponent<Animator>().SetTrigger("Die");
        StartCoroutine(DieWait());
    }

    private IEnumerator DieWait()
    {
        yield return new WaitForSeconds(2f);
        DarkCol.SetTrigger("D2");
        yield return new WaitForSeconds(1f);
        PD.DaIgrocUmer();
        Destroy(gameObject);
    }

    public void LoadSettings()
    {
        hasGateKey = ds.hasGateKey;
        аbility = ds.аbility;
        KeyPieces = ds.KeyPieces;
        SpecificKeyPieces = ds.SpecificKeyPieces;
        RepEl = ds.RepEl;

        Debug.Log("Сохранения игрока загружены");

        GlobalEventManager.SendAbilityLoadad();
    }

    public void SaveSettings()
    {
        ds.hasGateKey = hasGateKey;
        ds.аbility = аbility;
        ds.KeyPieces = KeyPieces;
        ds.SpecificKeyPieces = SpecificKeyPieces;
        ds.RepEl = RepEl;

        File.WriteAllText(msPath, JsonUtility.ToJson(ds));
    }

    public void TpOnPlatformerTpPoint()
    {
        transform.position = platformerTp;
        if(platformerRestoreEvent != null)
        {
            platformerRestoreEvent.Invoke();
        }
        au2.Play();
        GameManager.uCan = false;
        StartCoroutine(TpOnPlatformerTpPointWait());
    }

    private IEnumerator TpOnPlatformerTpPointWait()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.uCan = true;
    }

    [Serializable]
    public class PlayerSave
    {
        public bool hasGateKey;
        public bool[] аbility = new bool[3];
        public bool[] KeyPieces  = new bool[2];
        public bool[] SpecificKeyPieces = new bool[2];
        public bool RepEl;
    }
}
