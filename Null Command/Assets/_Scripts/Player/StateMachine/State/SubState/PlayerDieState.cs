using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerState
{
    PlayerLocomotion locomotion;

    public PlayerDieState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animationBool) : base(player, stateMachine, playerData, animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        base.Enter();
        locomotion = player.Locomotion;
        locomotion.SetHorizontalVelocity(0f, 0);

        player.Die();
    }
}
