using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Robot Data")]
public class RobotDataSO : ScriptableObject
{
    [Header("Locomotion")]
    [SerializeField] float moveSpeed = 0f;

    [Header("Checks")]
    [SerializeField] float wallCheckLength;
    [SerializeField] float ledgeCheckLength;
    [SerializeField] LayerMask platformLayer;

    public float MoveSpeed => moveSpeed;
    public float WallCheckLength => wallCheckLength;
    public float LedgeCheckLength => ledgeCheckLength;
    public LayerMask PlatformLayer => platformLayer;
}
