using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetWorkManager : MonoBehaviourPunCallbacks, IManager
{
    public static NetWorkManager Instance { get; private set; }

    //private bool isPlay;
    //public static bool IsPlay { get { return Instance.isPlay; } set { Instance.isPlay = value; } }

    private bool isTriggerCrown;
    public static bool IsTriggerCrown { get { return Instance.isTriggerCrown; } set { Instance.isTriggerCrown = value; } }

    public void Init()
    {
        Instance = this;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("마스터 서버");
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2;
        options.IsVisible = false;

        PhotonNetwork.JoinOrCreateRoom("Room11", options, TypedLobby.Default);
    }

    public override void OnLeftRoom()
    {
        //SceneManager.LoadScene("ResertScene");
        PhotonNetwork.LoadLevel(1); // 변경되는 씬의 넘버
    }

    // TODO : 마스터 클라이언트가 변경되었을 때
}
