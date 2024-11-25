using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState
{
    public RunState(PlayerController player) : base(player)
    {
        animationIndex = (int)E_PlayeState.Run;
    }

    public override void Enter()
    {
        Debug.Log("Run 진입");
        player.view.PlayAnimation(animationIndex);
    }

    public override void Update()
    {
        if (player.jumpBufferCounter > 0f && player.isJumpable)
        {
            player.ChangeState(E_PlayeState.Jump);
        }


        //if (RemoteInput.inputs[player.model.playerNumber].jumpInput && player.isJumpable)
        //{
        //    player.ChangeState(E_PlayeState.Jump);
        //}

        else if (player.moveDir.sqrMagnitude < 0.1f) //== Vector3.zero)
        {
            player.ChangeState(E_PlayeState.Idle);
        }
    }

    public override void FixedUpdate()
    {
        Run();
        LookForward();
    }

    public override void LateUpdate()
    {
        //LookForward();
    }

    public override void Exit()
    {
        Debug.Log("Run 종료");
    }

    private void Run()
    {
        Vector3 targetVelocity = player.moveDir * player.model.moveSpeed;
        targetVelocity.y = player.rb.velocity.y;

        player.rb.velocity = targetVelocity;

        //player.rb.velocity = player.moveDir * player.model.moveSpeed + Vector3.up * player.rb.velocity.y;
    }

    private void LookForward()
    {
        if (player.moveDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(player.moveDir);
            targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

            player.transform.rotation = Quaternion.Slerp(
                player.transform.rotation,
                targetRotation,
                Time.fixedDeltaTime * 15 // 수정필요
            );
        }
    }
}
