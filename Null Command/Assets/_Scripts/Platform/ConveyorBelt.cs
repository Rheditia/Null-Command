using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : InteractiblePlatform
{
    SurfaceEffector2D surfaceEffector;

    protected override void Awake()
    {
        base.Awake();
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    protected override void Start()
    {
        base.Start();
        surfaceEffector.speed = surfaceEffector.speed * transform.localScale.x;
        anim.SetBool("active", IsActive);
        surfaceEffector.enabled = IsActive;
    }

    private void Update()
    {
        if (anim.GetBool("active") != IsActive)
        {
            anim.SetBool("active", IsActive);
            surfaceEffector.enabled = IsActive;
        }
    }
}
