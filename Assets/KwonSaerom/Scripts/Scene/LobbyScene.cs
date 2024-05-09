using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
        //DB에서 플레이어의 정보를 들고와유
        PhotonNetwork.ConnectUsingSettings();
    }

}
