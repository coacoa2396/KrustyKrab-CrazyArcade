using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return 1f;
        PhotonNetwork.JoinLobby();
        yield return 2f;
        PhotonNetwork.NickName = Manager.Game.Player.key;
    }
}
