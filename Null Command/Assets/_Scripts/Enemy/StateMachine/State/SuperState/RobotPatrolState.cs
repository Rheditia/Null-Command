using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPatrolState : RobotState
{
    protected RobotLocomotion locomotion;
    public RobotPatrolState(Robot robot, RobotStateMachine stateMachine, RobotDataSO robotData, string animationBool) : base(robot, stateMachine, robotData, animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        locomotion = robot.Locomotion;
        robot.ResetPatrolTimer();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(robot.CheckIfTouchingWall() || !robot.CheckIfOnLedge())
        {
            robot.transform.localScale = new Vector3(-robot.transform.localScale.x, 1, 1);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
