using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Locomotion")]
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float jumpSpeed = 0f;

    [Header("Checks")]
    [SerializeField] float groundCheckRadius = 0f;
    [SerializeField] LayerMask platformLayer;

    public float MoveSpeed => moveSpeed;
    public float JumpSpeed => jumpSpeed;
    public float GroundCheckRadius => groundCheckRadius;
    public LayerMask PlatformLayer => platformLayer;
}
