using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BossOne : MonoBehaviour
{
    public AudioSource au1;
    public AudioSource au2;
    public AudioSource au3;

    public bool startOfTheBatle = false;
    public Transform batlePos;
    public Transform bossPos;
    private Animator anim;

    public Transform rotPoint;
    public RotpointScript RPS;

    //поведение
    private int RandomRangeMin = 0;
    private int RandomRangeMax = 3;
    private int repitings = 0;

    //Shot & TimeShot
    public GameObject[] shotPos = new GameObject[8];
    public GameObject BulletPrefub1;
    public GameObject BulletPrefub2;
    public AudioSource au;
    public Animator shotPointAnim;

    //Laser
    public Transform[] laserPos = new Transform[9];
    public GameObject lsPref;

    //Sow
    public GameObject SowPref;

    //FX
    public AudioSource FxAu1;
    public AudioSource FxAu1_2;
    public AudioSource FxAu2;
    public AudioSource FxAu3;
    public AudioSource FxAu4;
    public ParticleSystem ps;
    public Animation FxAnimSircl;

    public Animator gapAnim;
    public AudioSource gapAu;
    public PlayableDirector gapPd;

    public Animator endColorAnim;

    public TheChatDialog TCD;

    //Перемещение
    public Transform[] TpPoint = new Transform[3];
    public Transform target;
    public GameObject BossObj;
    private float Speed = 10f;
    private bool ItRun = false;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(ItRun) Run();
    }
    public void BatleStart()
    {
        startOfTheBatle = true;
        BossObj.transform.position = batlePos.position;
        anim.SetTrigger("Start");

        StartCoroutine(BossBehavior1());
        au1.Play();
    }
    //Поведение
    public IEnumerator BossBehavior1()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(Shot(BulletPrefub1, 1, 3, 1f));
        yield return new WaitForSeconds(4f);
        ItRun = true;
        target = batlePos;
        Сharging();
        yield return new WaitForSeconds(2f);
        //repitings = 15 + 1 + 1;
        while (true)
        {
            if (repitings == 3)
            {
                Сharging();
                RandomRangeMin = 2;
                RandomRangeMax = 6;
                yield return new WaitForSeconds(2f);
            }
            else if (repitings == 10)
            {
                Сharging();
                RandomRangeMin = 5;
                RandomRangeMax = 12;
                yield return new WaitForSeconds(2f);
            }
            else if (repitings == 15)
            {
                au1.mute = true;
                anim.SetTrigger("Glitsh");
                ControllerOfShake.Instance.InstShakeCamera(8, 1f);
                FxAu4.Play();
                yield return new WaitForSeconds(2f);
                au2.Play();
                yield return new WaitForSeconds(2f);
                yield return new WaitForSeconds(2f);
                RandomRangeMin = 12;
                RandomRangeMax = 12;
                Сharging();
                yield return new WaitForSeconds(4f);
                Сharging();
                yield return new WaitForSeconds(4f);
                Сharging();
                yield return new WaitForSeconds(4f);
            }
            else if (repitings == 16)
            {
                RandomRangeMin = 13;
                RandomRangeMax = 13;
                Сharging2();

                StartCoroutine(TCD.TheBossDialog2());

                yield return new WaitForSeconds(15f);
                gapAnim.SetTrigger("t1");
                gapAu.Play();
                FxAnimSircl.Play("sirc1");
                yield return new WaitForSeconds(1.5f);
                ps.Play();
            }



            int i = Random.Range(RandomRangeMin, RandomRangeMax);
            if (i == 0)
            {
                StartCoroutine(Shot(BulletPrefub1, 1, 3, 0.5f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 1, 3, 0.5f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 1, 3, 0.5f));
                yield return new WaitForSeconds(2f);
            }
            else if (i == 1)
            {
                StartCoroutine(Shot(BulletPrefub1, 1, 6, 0.1f));
            }
            else if (i == 2)
            {
                StartCoroutine(Shot(BulletPrefub1, 3, 3, 0.5f));
            }
            else if (i == 3)
            {
                StartCoroutine(TimeShot(BulletPrefub2, 3, 2, 0.05f, 0.05f));
            }
            else if (i == 4)
            {
                StartCoroutine(TimeShot(BulletPrefub2, 1, 3, 0f, 0.5f));
            }
            else if (i == 5)
            {
                StartCoroutine(TimeShot(BulletPrefub2, 8, 1, 0f, 0.1f));
            }
            else if (i == 6)
            {
                StartCoroutine(TimeShot(BulletPrefub1, 3, 6, 0.05f, 0.05f));
            }
            else if (i == 7)
            {
                StartCoroutine(TimeShot(BulletPrefub2, 8, 4, 0.05f, 0.01f));
            }
            else if (i == 8) 
            {
                StartCoroutine(Shot(BulletPrefub1, 8, 10, 0.1f));
            }
            else if (i == 9)
            {
                Speed = 10f;
                Tp(Random.Range(1, 3), false);
                target = GameObject.Find("- Player -(Clone)").transform;
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(Shot(BulletPrefub1, 3, 4, 0.2f));
                yield return new WaitForSeconds(1f);
                Speed = 40f;
                target = batlePos;
            }
            else if (i == 10)
            {
                ItRun = false;
                int y = Random.Range(0, 2);
                for (int z = 1; z!=5; z++)
                {
                    Tp(y, false);
                    if (y == 0) y = Random.Range(1, 2);
                    else if (y == 1) y = 2;
                    else if (y == 2) y = Random.Range(0, 1);
                    yield return new WaitForSeconds(0.2f);
                    StartCoroutine(Shot(BulletPrefub1, 3, z * 2, 0.1f));
                    yield return new WaitForSeconds(0.5f + (z * 2 * 0.1f));
                }
                ItRun = true;
            }
            else if (i == 11)
            {
                RPS.IsRotate = false;
                RPS.Rot = -90;
                shotPointAnim.SetTrigger("atk1");
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(Shot(BulletPrefub1, 8, 45, 0.1f));
                yield return new WaitForSeconds(7f);
                RPS.IsRotate = true;
            }
            //final
            else if(i == 12)
            {
                StartCoroutine(Shot(BulletPrefub1, 1, 3, 0.5f));
                yield return new WaitForSeconds(2f);
                ps.Play();
                StartCoroutine(Shot(BulletPrefub1, 1, 3, 0.5f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 1, 3, 0.5f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 1, 6, 0.1f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 3, 3, 0.5f));
                yield return new WaitForSeconds(3f);
                StartCoroutine(TimeShot(BulletPrefub2, 3, 1, 0f, 0f));
                yield return new WaitForSeconds(3f);
                StartCoroutine(TimeShot(BulletPrefub2, 1, 5, 0f, 0.5f));
                yield return new WaitForSeconds(3f);
                StartCoroutine(TimeShot(BulletPrefub2, 8, 1, 0f, 0.1f));
                yield return new WaitForSeconds(3f);

                ItRun = false;
                int y = Random.Range(0, 2);
                for (int z = 1; z != 5; z++)
                {
                    Tp(y, false);
                    if (y == 0) y = Random.Range(1, 2);
                    else if (y == 1) y = 2;
                    else if (y == 2) y = Random.Range(0, 1);
                    yield return new WaitForSeconds(0.2f);
                    StartCoroutine(Shot(BulletPrefub2, 3, z * 2, 0.1f));
                    yield return new WaitForSeconds(0.5f + (z * 2 * 0.1f)); //Ок
                }
                ItRun = true;
                yield return new WaitForSeconds(3f);

                Laser(lsPref, new Vector2( GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(2f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(2f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(2f);
                Сharging();
                yield return new WaitForSeconds(2f);
                for (int z = 0; z != 8; z++)
                {
                    Laser(lsPref, laserPos[z].position);
                    yield return new WaitForSeconds(0.5f);
                }
                yield return new WaitForSeconds(1f);
                for (int z = 8; z != 0; z--)
                {
                    Laser(lsPref, laserPos[z].position);
                    yield return new WaitForSeconds(0.5f);
                }
                yield return new WaitForSeconds(1f);

                for (int z = 0; z != 8; z+=2)
                {
                    Laser(lsPref, laserPos[z].position);
                    yield return new WaitForSeconds(0.2f);
                }
                yield return new WaitForSeconds(0.5f);
                for (int z = 1; z != 7; z += 2)
                {
                    Laser(lsPref, laserPos[z].position);
                    yield return new WaitForSeconds(0.2f);
                }
                yield return new WaitForSeconds(5f);

                anim.SetTrigger("Glitsh2");
                FxAu4.Play();
                yield return new WaitForSeconds(1.5f);

                StartCoroutine(Shot(BulletPrefub1, 3, 8, 0.5f));
                for (int z = 0; z != 4; z++)
                {
                    Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(1f);

                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(1.5f);
                RPS.IsRotate = false;
                RPS.Rot = -90;
                shotPointAnim.SetTrigger("atk1");
                yield return new WaitForSeconds(0.5f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                StartCoroutine(Shot(BulletPrefub1, 8, 45, 0.1f));
                yield return new WaitForSeconds(4f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(3f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                RPS.IsRotate = true;
                ps.Stop();

                StartCoroutine(TCD.TheBossDialog());

                yield return new WaitForSeconds(19f);
            }


            //Дубль 2
            else if (i == 13)
            {
                StartCoroutine(Shot(BulletPrefub1, 3, 3, 0.3f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 3, 3, 0.3f));
                yield return new WaitForSeconds(2f);
                StartCoroutine(Shot(BulletPrefub1, 3, 3, 0.3f));
                yield return new WaitForSeconds(2f);

                StartCoroutine(TimeShot(BulletPrefub2, 3, 3, 0.2f, 0f));
                yield return new WaitForSeconds(3f);
                StartCoroutine(TimeShot(BulletPrefub2, 1, 10, 0f, 0.2f));
                yield return new WaitForSeconds(5f);

                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(2f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(2f);
                Laser(lsPref, new Vector2(GameObject.Find("- Player -(Clone)").transform.position.x, -31f));
                yield return new WaitForSeconds(2f);

                StartCoroutine(TimeShot(SowPref, 1, 1, 0f, 0f));
                yield return new WaitForSeconds(4f);
                StartCoroutine(TimeShot(SowPref, 1, 1, 0f, 0f));
                yield return new WaitForSeconds(4f);
                StartCoroutine(TimeShot(SowPref, 1, 1, 0f, 0f));
                yield return new WaitForSeconds(4f);
                StartCoroutine(TimeShot(SowPref, 3, 1, 0.05f, 0.05f));
                yield return new WaitForSeconds(3f);
                gapPd.Play();

                yield return new WaitForSeconds(100f);
            }

            repitings++;
            yield return new WaitForSeconds(3f);
        }
    }

    public void GapOpen()
    {
        StartCoroutine(TheEndAttack());

        gapAnim.SetTrigger("t2");
        ControllerOfShake.Instance.InstShakeCamera(6, 2f);
    }

    public IEnumerator TheEndAttack()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(TimeShot(SowPref, 8, 1, 0.1f, 0.1f));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(TimeShot(SowPref, 8, 1, 0.1f, 0.1f));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(TimeShot(SowPref, 8, 1, 0.1f, 0.1f));
        yield return new WaitForSeconds(3f);

        Laser(lsPref, laserPos[4].position);
        yield return new WaitForSeconds(0.4f);
        Laser(lsPref, laserPos[5].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[3].position);
        yield return new WaitForSeconds(0.4f);
        Laser(lsPref, laserPos[6].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[2].position);
        yield return new WaitForSeconds(0.4f);
        Laser(lsPref, laserPos[7].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[1].position);
        yield return new WaitForSeconds(1.5f);
        Laser(lsPref, laserPos[8].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[0].position);
        yield return new WaitForSeconds(0.4f);
        Laser(lsPref, laserPos[7].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[1].position);
        yield return new WaitForSeconds(0.4f);
        Laser(lsPref, laserPos[6].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[2].position);
        yield return new WaitForSeconds(0.4f);
        Laser(lsPref, laserPos[5].position);
        yield return new WaitForSeconds(0.1f);
        Laser(lsPref, laserPos[3].position);
        yield return new WaitForSeconds(2f);

        StartCoroutine(TimeShot(SowPref, 3, 1, 0.1f, 0.1f));
        for (int z = 0; z != 4; z++)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Shot(BulletPrefub1, 1, 1, 0.3f));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(TimeShot(BulletPrefub2, 3, 1, 0.05f, 0.05f));
        }
        yield return new WaitForSeconds(1.5f);
        target = TpPoint[1];
        Tp(2, false);
        Speed = 30;
        StartCoroutine(TimeShot(BulletPrefub2, 1, 6, 0.15f, 0.05f));
        yield return new WaitForSeconds(1.5f);
        Tp(0, true);

        yield return new WaitForSeconds(1.5f);
        for (int z = 0; z != 8; z += 2)
        {
            SawInst(SowPref, laserPos[z].position, -90f);
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1f);
        for (int z = 1; z != 7; z += 2)
        {
            SawInst(SowPref, laserPos[z].position, -90f);
            yield return new WaitForSeconds(0.2f);
        }
        SawInst(SowPref, laserPos[7].position, -90f);
        yield return new WaitForSeconds(3f);

        StartCoroutine(Shot(SowPref, 1, 10, 0.2f));
        yield return new WaitForSeconds(4.3f);
        endColorAnim.SetTrigger("r");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("TheEnd");
    }

    //Атаки
    public IEnumerator Shot(GameObject Bullet, int colOfShot, int colOfRepiting, float time)
    {
        for (int i2 = 0; i2 != colOfRepiting; i2++)
        {
            for (int i = 0; i != colOfShot; i++)
            {
                Instantiate(Bullet, shotPos[i].transform.position, shotPos[i].transform.rotation);
            }
            au.Play();
            yield return new WaitForSeconds(time);
        }
    }
    public IEnumerator TimeShot(GameObject Bullet, int colOfShot, int colOfRepiting, float time, float time2)
    {
        for (int i2 = 0; i2 != colOfRepiting; i2++)
        {
            for (int i = 0; i != colOfShot; i++)
            {
                Instantiate(Bullet, shotPos[i].transform.position, shotPos[i].transform.rotation);
                yield return new WaitForSeconds(time2);
            }
            yield return new WaitForSeconds(time);
        }
    }

    public void Laser(GameObject laser, Vector2 pos)
    {
        Instantiate(laser, pos, laser.transform.rotation);
    }

    public void SawInst(GameObject saw, Vector2 pos, float rot)
    {
        Instantiate(saw, pos, Quaternion.Euler(0f, 0f, rot));
    }

    //FX
    public void Сharging()
    {
        FxAu1.Play();
        anim.SetTrigger("Fx1");
    }
    public void Сharging2()
    {
        FxAu1_2.Play();
        anim.SetTrigger("Fx1_2");
    }

    // * Перемещение

    //Телепортация
    public void Tp(int i, bool SetTar)
    {
        BossObj.transform.position = new Vector2 (TpPoint[i].position.x, TpPoint[i].position.y);
        anim.SetTrigger("tp");
        FxAu3.Play();
        if (SetTar) target = TpPoint[i];
    }
    public void Run()
    {
        BossObj.transform.position = Vector2.MoveTowards(BossObj.transform.position, target.position, Speed * Time.deltaTime);
    }
}
