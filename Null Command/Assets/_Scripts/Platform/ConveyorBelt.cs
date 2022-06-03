using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    SurfaceEffector2D surfaceEffector;

    private void Awake()
    {
        surfaceEffector = GetComponent<SurfaceEffector2D>();
    }

    private void Start()
    {
        surfaceEffector.speed = surfaceEffector.speed * transform.localScale.x;
    }
}
