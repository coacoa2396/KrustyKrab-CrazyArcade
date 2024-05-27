using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] UI_Room roomPopup;
    [SerializeField] UI_LobbyScene lobbyScene;

    private ClientState state;
    private List<RoomEntity> createdRooms;
    private UI_Room nowRoomPopup;

    public static int RoomNum = 0; //동기화 필요
    public static RoomEntity NowRoom; //현재 플레이어가 들어온 방의 정보 


    private void Awake()
    {
        createdRooms = new List<RoomEntity>();
    }

    private void Start()
    {
        if (PhotonNetwork.InRoom)
            LoadRoom();
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
        Debug.Log("OnJoinedLobby");
    }

    /// 방
    public override void OnCreatedRoom()
    {
        RoomNum++;
        Debug.Log("OnCreatedRoom");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        createdRooms.Clear();
        NowRoom = null;
        PhotonNetwork.JoinLobby();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        Debug.Log(RoomNum);
        RoomNum++;
    }
    public override void OnJoinedRoom()
    {
        //캐릭터 설정
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "Character", 0 } });
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "Ready", false } });

        //방 정보를 들고와서 UI에 연결
        LoadRoom();
    }

    public void LoadRoom()
    {
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "IsLoad", false } });

        RoomEntity entity = new RoomEntity(PhotonNetwork.CurrentRoom);
        NowRoom = entity;
        NowRoom.NowPlayer = PhotonNetwork.CurrentRoom.PlayerCount;

        //방 팝업 켜기
        UI_Room room = Manager.UI.ShowPopUpUI(roomPopup);
        nowRoomPopup = room;
        room.SetRoomInfo(NowRoom);

        PhotonNetwork.AutomaticallySyncScene = true;
    }


    public override void OnLeftRoom()
    {
        Debug.Log("방에서 나감");
        nowRoomPopup.Close();
        nowRoomPopup = null;

        PhotonNetwork.AutomaticallySyncScene = false;
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        Debug.Log("방 정보가 변경됨");
        nowRoomPopup.RoomChange();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log(roomList.Count);
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
                    int roomInfoNum = int.Parse(roomInfo.Name);
                    if (createdRooms[i].RoomNum == roomInfoNum)
                    {
                        Hashtable ht = roomInfo.CustomProperties;
                        Debug.Log(ht.Count);
                        Debug.Log((string)ht["RoomName"]);
                        createdRooms[i].UpdateRoomInfo((string)ht["RoomName"], roomInfo.PlayerCount);
                        createdRooms[i].MaxPlayer = roomInfo.MaxPlayers;
                        isNew = false;
                    }
                }
                if(isNew)
                {
                    RoomNum = int.Parse(roomInfo.Name) + 1;
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
