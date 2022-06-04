using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Robot Data")]
public class RobotDataSO : ScriptableObject
{
    [Header("Locomotion")]
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float patrolDelay = 3f;

    [Header("Checks")]
    [SerializeField] Vector2 groundCheckSize;
    [SerializeField] float wallCheckLength;
    [SerializeField] float ledgeCheckLength;
    [SerializeField] LayerMask platformLayer;

    public float MoveSpeed => moveSpeed;
    public float PatrolDelay => patrolDelay;
    public Vector2 GroundCheckSize => groundCheckSize;
    public float WallCheckLength => wallCheckLength;
    public float LedgeCheckLength => ledgeCheckLength;
    public LayerMask PlatformLayer => platformLayer;
}
