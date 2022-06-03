using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Switch
{
    BoxCollider2D boxCollider;
    protected override void Awake()
    {
        base.Awake();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if ((anim.GetBool("active") != IsActive) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            anim.SetBool("active", IsActive);
            foreach(InteractiblePlatform platform in platforms)
            {
                platform.IsActive = IsActive;
            }
        }
    }
}
