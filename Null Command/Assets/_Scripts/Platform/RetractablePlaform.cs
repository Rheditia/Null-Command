using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractablePlaform : MonoBehaviour
{
    Animator anim;
    BoxCollider2D boxCollider;

    [SerializeField] bool isActive;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        anim.SetBool("active", isActive);
        boxCollider.enabled = isActive;
    }

    private void Update()
    {
        if(anim.GetBool("active") != isActive)
        {
            anim.SetBool("active", isActive);
            boxCollider.enabled = isActive;
        }
    }
}
