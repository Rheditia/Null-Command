using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateMachine
{
    public RobotState CurrentState { get; private set; }

    public void InitializeState(RobotState state)
    {
        CurrentState = state;
        CurrentState.Enter();
    }

    public void ChangeState(RobotState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
