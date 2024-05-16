using Firebase.Extensions;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyScene : InGameUI
{
    [SerializeField] UI_CreateRoom createRoomPopup;

    private UI_RoomToken[] roomTokens;

    enum GameObjects
    {
        CreateRoomButton,
        QuitButton,
        QuickPlayButton
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.CreateRoomButton.ToString()).onClick.AddListener(CreateRoom);
        GetUI<Button>(GameObjects.QuitButton.ToString()).onClick.AddListener(Quit);
        GetUI<Button>(GameObjects.QuickPlayButton.ToString()).onClick.AddListener(QuickJoinRoom);
        roomTokens = GetComponentsInChildren<UI_RoomToken>();
        foreach(UI_RoomToken token in roomTokens)
        {
            token.OffActive();
        }
    }


    public void CreateRoom()
    {
        Manager.UI.ShowPopUpUI(createRoomPopup);
    }
    
    public void QuickJoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        //Debug.Log(PhotonNetwork.CurrentRoom.Name);
        //LobbyManager.NowRoom = new RoomEntity(PhotonNetwork.CurrentRoom);
    }

    public void Quit()
    {
        SetInteractable(false);
        Manager.Game.Logout();
        Manager.Scene.LoadScene("TitleScene");
    }

    private void SetInteractable(bool interactable)
    {
        GetUI<Button>(GameObjects.QuitButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.CreateRoomButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.QuickPlayButton.ToString()).interactable = interactable;
    }

    public void UpdateRoomList(List<RoomEntity> roomList)
    {
        //방 정보에 따라 변경.(덮어쓰기)
        for(int i=0;i< roomList.Count; i++)
        {
            roomTokens[i].SetRoomInfo(roomList[i]);
        }

        //방이 없는 부분은 UI 끈다.
        for(int i=roomList.Count;i< roomTokens.Length;i++)
        {
            roomTokens[i].OffActive();
        }
    
    }
}
