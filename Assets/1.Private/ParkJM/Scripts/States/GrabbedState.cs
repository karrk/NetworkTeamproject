using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbedState : PlayerState
{
    public GrabbedState(PlayerController player) : base(player)
    {

    }

    public override void Enter()
    {
        Debug.Log("잡힘 상태 진입");
        // Todo : 잡혔을때 해줄 동작
        player.rb.velocity = Vector3.zero;
    }

    public override void Update()
    {
        // 임시 잡힌상태 나가기
        if(player.jumpBufferCounter > 0f && player.isJumpable)
        {
            player.ChangeState(E_PlayeState.Jump);
        }
    }

    public override void FixedUpdate()
    {
        
    }

    public override void Exit()
    {

    }

}
