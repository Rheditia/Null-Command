using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMoveState : RobotPatrolState
{
    public RobotMoveState(Robot robot, RobotStateMachine stateMachine, RobotDataSO robotData, string animationBool) : base(robot, stateMachine, robotData, animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        robot.PatrolTimerCountdown();
        if (robot.Patrol)
        {
            stateMachine.ChangeState(robot.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        locomotion.SetHorizontalVelocity(robotData.MoveSpeed, robot.transform.localScale.x);
    }
}
