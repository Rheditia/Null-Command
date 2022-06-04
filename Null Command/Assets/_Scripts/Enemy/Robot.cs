using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    #region StateMachine
    public RobotStateMachine StateMachine { get; private set; }
    public RobotIdleState IdleState { get; private set; }
    public RobotMoveState MoveState { get; private set; }
    #endregion

    #region Component
    [SerializeField] RobotDataSO robotData;
    public Animator Anim { get; private set; }
    private BoxCollider2D myCollider;
    public RobotLocomotion Locomotion { get; private set; }
    #endregion

    #region Variable
    [SerializeField] Transform wallCheckPosition;
    [SerializeField] Transform ledgeCheckPosition;
    [SerializeField] Transform groundCheckPosition;
    public bool Patrol => patrolTimer < 0;
    private float patrolTimer;
    #endregion

    #region UnityCallbacks
    private void Awake()
    {
        StateMachine = new RobotStateMachine();
        Anim = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        Locomotion = GetComponent<RobotLocomotion>();

        IdleState = new RobotIdleState(this, StateMachine, robotData, "idle");
        MoveState = new RobotMoveState(this, StateMachine, robotData, "move");
    }

    private void Start()
    {
        patrolTimer = robotData.PatrolDelay;
        StateMachine.InitializeState(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Checks
    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPosition.position, robotData.GroundCheckSize, 0, robotData.PlatformLayer);
    }
    public bool CheckIfTouchingWall()
    {
        return Physics2D.Raycast(wallCheckPosition.position, Vector2.right * transform.localScale.x, robotData.WallCheckLength, robotData.PlatformLayer);
    }

    public bool CheckIfOnLedge()
    {
        return Physics2D.Raycast(ledgeCheckPosition.position, Vector2.down, robotData.LedgeCheckLength, robotData.PlatformLayer);
    }
    #endregion

    #region Other Functions
    public void PatrolTimerCountdown()
    {
        if(patrolTimer > 0) { patrolTimer -= Time.deltaTime; }
        else { return; }
    }

    public void ResetPatrolTimer()
    {
        patrolTimer = robotData.PatrolDelay;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(wallCheckPosition.position, wallCheckPosition.position + (Vector3.right * transform.localScale.x) * robotData.WallCheckLength);
        Gizmos.DrawLine(ledgeCheckPosition.position, ledgeCheckPosition.position + Vector3.down * robotData.LedgeCheckLength);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPosition.position, robotData.GroundCheckSize);
    }
}
