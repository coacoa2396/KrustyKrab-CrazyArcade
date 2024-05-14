using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUserController : MonoBehaviourPunCallbacks
{
    private UI_UserToken[] userTokens;
    private List<UserEntity> players;

    private void Start()
    {
        userTokens = GetComponentsInChildren<UI_UserToken>();
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for(int i=0;i<userTokens.Length;i++)
        {
            if (i < maxPlayer)
                userTokens[i].SetVisit(true);
            else
                userTokens[i].SetVisit(false);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogError(newPlayer.NickName+" 들어옴");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogError(otherPlayer.NickName+" 나감");
    }
}
