using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    protected Animator anim;
    protected InteractiblePlatform[] platforms;

    [SerializeField] bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        platforms = GetComponentsInChildren<InteractiblePlatform>();
        foreach (InteractiblePlatform platform in platforms)
        {
            platform.IsActive = isActive;
        }
    }

    protected virtual void Start()
    {
        anim.SetBool("active", isActive);
    }
}
