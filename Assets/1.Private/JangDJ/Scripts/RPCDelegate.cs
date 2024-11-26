using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RPCDelegate : MonoBehaviourPun
{
    [SerializeField] private DeadZone _deadZone;

    private void Awake()
    {
        EffectManager.Instance.Del = this;
        _deadZone.Del = this;
    }

    public void PlayFX(Vector3 requestPos, E_VFX vfxType)
    {
        photonView.RPC(nameof(PlayFXRPC), RpcTarget.All, requestPos, vfxType);
    }

    [PunRPC]
    private void PlayFXRPC(Vector3 requestPos, E_VFX vfxType)
    {
        EffectManager.Instance.PlayFX(requestPos, vfxType,E_NetworkType.Private);
    }

    private void OnDisable()
    {
        EffectManager.Instance.Del = null;
    }

    public void DeadPlayer(int viewId)
    {
        if (PhotonNetwork.IsMasterClient == false)
            return;

        photonView.RPC(nameof(DestroyPlayer), RpcTarget.All, viewId);
    }

    [PunRPC]
    private void DestroyPlayer(int viewId)
    {
        PhotonNetwork.Destroy(PhotonNetwork.GetPhotonView(viewId).gameObject);
    }
}
