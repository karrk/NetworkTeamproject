using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(PlayerController player) : base(player)
    {
        animationIndex = (int)E_PlayeState.Idle;
    }

    public override void Enter()
    {
        Debug.Log("Idle 진입");
        player.rb.velocity = Vector3.zero;
        player.isJumpable = true; // 임시, spawn 상태에서 해주는것이 좋을듯
        player.view.PlayAnimation(animationIndex);
    }

    public override void Update()
    {
        if (player.jumpBufferCounter > 0f && player.isJumpable)
        {
            player.ChangeState(E_PlayeState.Jump);
        }
        else if (player.moveDir != Vector3.zero && player.isGrounded)
        {
            player.ChangeState(E_PlayeState.Run);
        }
        else if(!player.isGrounded && player.rb.velocity.y != 0)
        {
            player.ChangeState(E_PlayeState.Fall);
        }
        else if(RemoteInput.inputs[player.model.playerNumber].divingInput)
        {
            player.ChangeState(E_PlayeState.Diving);
        }
        else if (RemoteInput.inputs[player.model.playerNumber].grabInput)
        {
            player.ChangeState(E_PlayeState.Grabbing);
        }

        //else
        //{
        //    //Debug.Log($"점프 안됨 리모트 인풋 : {RemoteInput.inputs[player.model.playerNumber].jumpInput}");
        //    //Debug.Log($"player.isJumping : {player.isJumping}");
        //}



        // Todo : fall 상태 전환
        //if(player.rb.velocity.y < 0)
        //{

        //}

        //moveDir = RemoteInput.inputs[playerNumber].MoveDir;
        //rotVec = RemoteInput.inputs[playerNumber].RotVec;
    }

    public override void FixedUpdate()
    {
        
    }

    public override void Exit()
    {
        Debug.Log("Idle 종료");
    }

}
