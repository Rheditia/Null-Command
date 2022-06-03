using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerGroundedState : PlayerState
{
    protected PlayerLocomotion locomotion;
    protected PlayerInputHandler inputHandler;
    protected PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animationBool) : base(player, stateMachine, playerData, animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        locomotion = player.Locomotion;
        inputHandler = player.InputHandler;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (inputHandler.JumpInput)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (inputHandler.InteractInput)
        {
            stateMachine.ChangeState(player.InterractState);
        }
        else if (!player.CheckIfGrounded() && locomotion.VerticalVelocity < 0)
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
