using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GostEffect : MonoBehaviour
{
    public GameObject gostPrefab;

    public float delay = 1.0f;
    float delta = 0;

    PlayerMovement player;
    SpriteRenderer spriteRenderer;
    public float destroyTime = 0.1f;
    public Material material = null;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (delta > 0) { delta -= Time.deltaTime; }
        else { delta = delay; CreateGost(); }
    }

    private void CreateGost()
    {
        GameObject gostObj = Instantiate(gostPrefab, transform.position, transform.rotation);
        gostObj.transform.localScale = player.transform.localScale;
        Destroy(gostObj, destroyTime);

        spriteRenderer = gostObj.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = player.spriteRenderer.sprite;
        spriteRenderer.flipX = player.spriteRenderer.flipX;

        if (material != null) spriteRenderer.material = material;
    }
}
