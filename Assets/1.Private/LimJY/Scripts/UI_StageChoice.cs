using Photon.Pun;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageChoice : MonoBehaviourPun
{
    [SerializeField] private PlayMatch playMath;
    [SerializeField] List<Sprite> MapScreenShot;

    [Header("변경내용")]
    [SerializeField] Image CurScreenShot;
    [SerializeField] TMP_Text CossName;
    [SerializeField] TMP_Text CossEx;


    private void Start()
    {
        playMath = GetComponent<PlayMatch>();

        CurScreenShot.sprite = null;
        CossName.text = "";
        CossEx.text = "";

        playMath.onChangeStageNum += StageSetUse;
    }

    void StageSetUse()
    {
        photonView.RPC("OnStageSet", RpcTarget.All);
    }

    [PunRPC]
    void OnStageSet()
    {
        Debug.Log("스테이지 선정 완료");

        switch (playMath.num)
        {
            case 0: // 산 무너져유
                Mountine();
                break;
            case 1: // 바닥 떨어져유
                Floor();
                break;
            case 2: // 점프 쇼다운
                Jump();
                break;
            case 3: // 롤아웃
                Roll();
                break;
        }
    }

    // === === === 

    void Mountine()
    {
        CurScreenShot.sprite = MapScreenShot[playMath.num];
        CossName.text = "산 무너져유";
        CossEx.text = "왕관에 가장 먼저 닿는 플레이어가 승리합니다!";
    }

    void Floor()
    {
        CurScreenShot.sprite = MapScreenShot[playMath.num];
        CossName.text = "바닥 떨어져유";
        CossEx.text = "타일을 밟고 난 후 일정 시간이 경과할 때 마다, 바닥 타일이 하나씩 사라집니다. \n\n떨어지지 않고 가장 오래 살아남는 플레이어가 승리합니다!";
    }

    void Jump()
    {
        CurScreenShot.sprite = MapScreenShot[playMath.num];
        CossName.text = "점프 쇼다운";
        CossEx.text = "돌아가는 장애물을 피해서 가장 오래 살아남는 플레이어가 승리합니다! \n\n장애물은 시간이 지날수록 속도가 빨라집니다.";
    }

    void Roll()
    {
        CurScreenShot.sprite = MapScreenShot[playMath.num];
        CossName.text = "롤 아웃";
        CossEx.text = "굴러가는 바닥 위에서 떨어지지 않고, 가장 오래 살아남는 플레이어가 승리합니다!";
    }
}
