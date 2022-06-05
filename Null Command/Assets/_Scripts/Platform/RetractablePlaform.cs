using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetractablePlaform : InteractiblePlatform
{
    BoxCollider2D boxCollider;
    AudioPlayer audioPlayer;
    protected override void Awake()
    {
        base.Awake();
        boxCollider = GetComponent<BoxCollider2D>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    protected override void Start()
    {
        base.Start();
        boxCollider.enabled = IsActive;
    }

    private void Update()
    {
        if(anim.GetBool("active") != IsActive)
        {
            audioPlayer.PlayRetractClip();
            anim.SetBool("active", IsActive);
            boxCollider.enabled = IsActive;
        }
    }
}
