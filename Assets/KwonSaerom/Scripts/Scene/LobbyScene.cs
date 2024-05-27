using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        //플레이어 연결
        if(PhotonNetwork.InRoom == false)
        {
            UserDataManager.LocalUserSetConnect(Define.CONNECT_NUM);
            yield return new WaitForSecondsRealtime(1f);
            PhotonNetwork.JoinLobby();
        }
        yield return new WaitForSecondsRealtime(2f);
        PhotonNetwork.NickName = Manager.Game.Player.User.key;
    }
}
