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
    public PlayerInterractState InterractState { get; private set; }
    public PlayerDieState DieState { get; private set; }
    #endregion

    #region Component
    [SerializeField] PlayerDataSO playerData;
    public Animator Anim { get; private set; }
    private BoxCollider2D myCollider;
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerLocomotion Locomotion { get; private set; }
    #endregion

    #region Variable
    [SerializeField] Transform groundCheckPosition;
    public bool IsAlive { get; private set; }
    #endregion

    #region UnityCallbacks
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        Anim = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Locomotion = GetComponent<PlayerLocomotion>();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InterractState = new PlayerInterractState(this, StateMachine, playerData, "interact");
        DieState = new PlayerDieState(this, StateMachine, playerData, "die");
    }

    private void Start()
    {
        IsAlive = true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, collision.gameObject.layer);
            IsAlive = false;
        }
    }
    #endregion

    public void Die()
    {
        Destroy(gameObject, 1f);
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPosition.position, playerData.GroundCheckSize, 0, playerData.PlatformLayer);
    }

    public void SetSwitch()
    {
        Collider2D switchControl = Physics2D.OverlapBox(transform.position, myCollider.size, 0, playerData.SwitchLayer);
        if(switchControl != null)
        {
            Switch switchComponent = switchControl.GetComponent<Switch>();
            switchComponent.IsActive = !switchComponent.IsActive;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(groundCheckPosition.position, playerData.GroundCheckSize);
    }
}
