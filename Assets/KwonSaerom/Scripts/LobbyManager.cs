using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] UI_Room roomPopup;
    [SerializeField] UI_LobbyScene lobbyScene;
    private ClientState state;

    public static int RoomNum = 0; //동기화 필요
    public static RoomEntity NowRoom; //현재 플레이어가 들어온 방의 정보 

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Update()
    {
        ClientState curState = PhotonNetwork.NetworkClientState;
        if (state == curState)
            return;
        state = curState;
        Debug.Log(state);
    }

    public override void OnConnected()
    {
        Debug.Log("OnConnected");
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
    }


    /// 방
    public override void OnCreatedRoom()
    {
        RoomNum++;
        Debug.Log("만듦");
    }

    public override void OnJoinedRoom()
    {
        UI_Room room = Manager.UI.ShowPopUpUI(roomPopup);
        room.SetRoomInfo(NowRoom);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        lobbyScene.UpdateRoomList(roomList);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }
    ///
}
