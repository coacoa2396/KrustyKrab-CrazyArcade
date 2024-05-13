using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] UI_Room roomPopup;
    [SerializeField] UI_LobbyScene lobbyScene;
    
    private ClientState state;
    private List<RoomEntity> createdRooms;

    public static int RoomNum = 0; //동기화 필요
    public static RoomEntity NowRoom; //현재 플레이어가 들어온 방의 정보 

    private void Awake()
    {
        //PhotonNetwork.ConnectUsingSettings();
        createdRooms = new List<RoomEntity>();
    }

    private void Update()
    {
        ClientState curState = PhotonNetwork.NetworkClientState;
        if (state == curState)
            return;
        state = curState;
        Debug.Log(state);
    }


    /// 방
    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
        SetRoomNum();
        CreateRoomInLobby(NowRoom);
    }

    public override void OnJoinedRoom()
    {
        UI_Room room = Manager.UI.ShowPopUpUI(roomPopup);
        room.SetRoomInfo(NowRoom);
    }

    public override void OnLeftRoom()
    {
        Debug.Log("방에서 나감");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.LogError("방 리스트 Update");
        foreach (RoomInfo roomInfo in roomList)
        {
            //방이 사라짐
            if (roomInfo.RemovedFromList || roomInfo.IsOpen == false || roomInfo.IsVisible == false)
            {
                for(int i=0;i< createdRooms.Count;i++)
                {
                    if (createdRooms[i].RoomNum == int.Parse(roomInfo.Name))
                        createdRooms.Remove(createdRooms[i]); //방을 지운다
                }
            }
            //방이 생기면 -> RoomNum++ 하기
            else
            {
                for (int i = 0; i < createdRooms.Count; i++)
                {
                    //방이 생긴다.
                    if (createdRooms[i].RoomNum == int.Parse(roomInfo.Name))
                        createdRooms.Remove(createdRooms[i]); //방을 지운다
                }
            }
        }
        lobbyScene.UpdateRoomList(createdRooms);
    }
     
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }


    private void SetRoomNum()
    {
        RoomNum++;
    }

    private void CreateRoomInLobby(RoomEntity entity)
    {
        createdRooms.Add(entity);
        lobbyScene.UpdateRoomList(createdRooms);
    }

}
