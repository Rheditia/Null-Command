using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : InteractiblePlatform
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
        boxCollider.enabled = !IsActive;
    }

    private void Update()
    {
        if (anim.GetBool("active") != IsActive)
        {
            anim.SetBool("active", IsActive);
            boxCollider.enabled = !IsActive;
        }
    }
}
