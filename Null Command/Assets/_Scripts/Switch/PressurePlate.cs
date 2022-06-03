using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Switch
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactible"))
        {
            IsActive = true;
            anim.SetBool("active", IsActive);
            foreach (InteractiblePlatform platform in platforms)
            {
                platform.IsActive = IsActive;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactible"))
        {
            IsActive = false;
            anim.SetBool("active", IsActive);
            foreach (InteractiblePlatform platform in platforms)
            {
                platform.IsActive = IsActive;
            }
        }
    }
}
