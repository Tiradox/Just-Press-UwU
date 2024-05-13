using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgParalax : MonoBehaviour
{
    [SerializeField] Transform followingTarget;
    [SerializeField, Range(0f, 1f)] float paralaxAttac = 1f;
    [SerializeField] bool VertPar;
    [SerializeField] public bool IsOn;
    Vector3 targetPrevuPosition;
    void Start()
    {
        if (!followingTarget)
            followingTarget = Camera.main.transform;

        targetPrevuPosition = followingTarget.position;
    }

    void Update()
    {
        if(IsOn)
        {
            Vector3 delta = followingTarget.position - targetPrevuPosition;

            if (VertPar)
                delta.y = 0;
            targetPrevuPosition = followingTarget.position;

            transform.position += (delta / 50) * paralaxAttac * -1;
        }
    }
}
