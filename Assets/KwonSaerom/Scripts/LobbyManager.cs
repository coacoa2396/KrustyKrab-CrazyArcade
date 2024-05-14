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


    public override void OnJoinedLobby()
    {
        Debug.LogError("OnJoinedLobby");
    }

    public override void OnLeftLobby()
    {
        Debug.LogError("OnLeftLobby");
    }

    /// 방
    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
        RoomNum++;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        createdRooms.Clear();
        bool suc = PhotonNetwork.JoinLobby();
        Debug.LogError(suc);
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
                    int roomInfoNum = int.Parse(roomInfo.Name.Split('/')[0]);
                    if (createdRooms[i].RoomNum == roomInfoNum)
                        createdRooms.Remove(createdRooms[i]); //방을 지운다
                }
            }
            else
            {
                bool isNew = true;
                for (int i = 0; i < createdRooms.Count; i++)
                {
                    int roomInfoNum = int.Parse(roomInfo.Name.Split('/')[0]);
                    if (createdRooms[i].RoomNum == roomInfoNum)
                    {
                        //방 정보 업데이트

                    }
                }
                if(isNew)
                {
                    RoomNum++;
                    RoomEntity entity = new RoomEntity(roomInfo);
                    createdRooms.Add(entity);
                }
            }
        }
        lobbyScene.UpdateRoomList(createdRooms);
    }
     
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }

}
