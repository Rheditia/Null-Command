using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotState 
{
    protected Robot robot;
    protected RobotStateMachine stateMachine;
    protected RobotDataSO robotData;
    protected string animationBool;

    public RobotState(Robot robot, RobotStateMachine stateMachine, RobotDataSO robotData, string animationBool)
    {
        this.robot = robot;
        this.stateMachine = stateMachine;
        this.robotData = robotData;
        this.animationBool = animationBool;
    }

    public virtual void Enter()
    {
        robot.Anim.SetBool(animationBool, true);
        //Debug.Log(animationBool);
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {
        robot.Anim.SetBool(animationBool, false);
    }
}
