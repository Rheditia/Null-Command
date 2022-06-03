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
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] LayerMask platformLayer;
    [SerializeField] LayerMask switchLayer;

    public float MoveSpeed => moveSpeed;
    public float JumpSpeed => jumpSpeed;
    public Vector2 GroundCheckSize => groundCheckSize;
    public LayerMask PlatformLayer => platformLayer;
    public LayerMask SwitchLayer => switchLayer;
}
