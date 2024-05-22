using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        //플레이어 연결
        if(PhotonNetwork.InLobby == false)
        {
            UserDataManager.LocalUserSetConnect(1);
            yield return 1f;
            PhotonNetwork.JoinLobby();
        }
        yield return 2f;
        PhotonNetwork.NickName = Manager.Game.Player.User.key;
    }
}
