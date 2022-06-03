using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    Animator anim;
    SurfaceEffector2D surfaceEffector;

    [SerializeField] bool isActive;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    private void Start()
    {
        surfaceEffector.speed = surfaceEffector.speed * transform.localScale.x;
        anim.SetBool("active", isActive);
        surfaceEffector.enabled = isActive;
    }

    private void Update()
    {
        if (anim.GetBool("active") != isActive)
        {
            anim.SetBool("active", isActive);
            surfaceEffector.enabled = isActive;
        }
    }
}
