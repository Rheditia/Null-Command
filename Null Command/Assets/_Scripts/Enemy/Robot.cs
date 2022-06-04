using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    #region StateMachine
    public RobotStateMachine StateMachine { get; private set; }
    #endregion

    #region Component
    [SerializeField] RobotDataSO robotData;
    public Animator Anim { get; private set; }
    private BoxCollider2D myCollider;
    public RobotLocomotion Locomotion { get; private set; }
    #endregion

    #region Variable
    #endregion

    #region UnityCallbacks
    private void Awake()
    {
        StateMachine = new RobotStateMachine();
        Anim = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        Locomotion = GetComponent<RobotLocomotion>();
    }

    private void Start()
    {
        //TODO Initialize state
    }

    private void Update()
    {
        //StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        //StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
}
