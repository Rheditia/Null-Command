using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLocomotion : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetHorizontalVelocity(float velocity, float horizontalInput)
    {
        Vector2 newVelocity = new Vector2(velocity * horizontalInput, myRigidbody.velocity.y);
        myRigidbody.velocity = newVelocity;
    }

    public void Flip(float input)
    {
        transform.localScale = new Vector3(Mathf.Sign(input), 1, 1);
    }
}
