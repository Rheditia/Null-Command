using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region StateMachine
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    #endregion

    #region Component
    [SerializeField] PlayerDataSO playerData;
    public Animator Animator { get; private set; }
    private BoxCollider2D myCollider;
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerLocomotion Locomotion { get; private set; }
    #endregion

    #region Variable
    [SerializeField] Transform groundCheckPosition;
    #endregion

    #region UnityCallbacks
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        Animator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Locomotion = GetComponent<PlayerLocomotion>();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
    }

    private void Start()
    {
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

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPosition.position, playerData.GroundCheckSize, 0, playerData.PlatformLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPosition.position, playerData.GroundCheckSize);
    }
}
