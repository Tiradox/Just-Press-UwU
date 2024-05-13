using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgParalax2 : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float paralaxAttac = 1f;
    [SerializeField] public bool IsOn;
    public float offSet;
    Vector3 targetPrevuPosition;
    void Start()
    {
        if (!followingTarget)
            followingTarget = Camera.main.transform;

        targetPrevuPosition.x = followingTarget.position.x;
    }

    void Update()
    {
        Vector3 delta = followingTarget.position - targetPrevuPosition;

        delta.y = offSet;
        targetPrevuPosition = followingTarget.position;

        transform.position += (delta) * paralaxAttac;
    }
}
