using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotIdleState : RobotPatrolState
{
    public RobotIdleState(Robot robot, RobotStateMachine stateMachine, RobotDataSO robotData, string animationBool) : base(robot, stateMachine, robotData, animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        locomotion.SetHorizontalVelocity(0f, robot.transform.localScale.x);
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
            stateMachine.ChangeState(robot.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
