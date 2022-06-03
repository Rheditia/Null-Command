using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterractState : PlayerAbilityState
{
    public PlayerInterractState(Player player, PlayerStateMachine stateMachine, PlayerDataSO playerData, string animationBool) : base(player, stateMachine, playerData, animationBool)
    {
    }

    public override void Enter()
    {
        base.Enter();
        locomotion.SetHorizontalVelocity(0f, inputHandler.MoveInput.x);
        inputHandler.ClearInteractBuffer();

        //TODO add method that will activate lever/interactible
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(player.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            isAbilityDone = true;
        }
    }
}
