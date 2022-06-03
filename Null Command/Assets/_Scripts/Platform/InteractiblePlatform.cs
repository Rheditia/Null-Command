using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiblePlatform : MonoBehaviour
{
    protected Animator anim;

    [SerializeField] bool isActive;
    public bool IsActive
    {
        protected get { return isActive; }
        set { isActive = value; }
    }

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        anim.SetBool("active", isActive);
    }
}
