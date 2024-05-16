using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room : PopUpUI
{
    RoomUserController roomController;

    enum GameObjects
    {
        SelectMapButton,
        GameStartButton,
        RoomName,
        RoomNumber,
        ExitButton,
        DaoSelect,
        CappiSelect,
        BazziSelect,
        MaridSelect
    }


    protected override void Awake()
    {
        base.Awake();
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        GetUI<Button>(GameObjects.ExitButton.ToString()).onClick.AddListener(ExitRoom);
        GetUI<Button>(GameObjects.GameStartButton.ToString()).onClick.AddListener(GameStart);
        GetUI<Button>(GameObjects.DaoSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Dao));
        GetUI<Button>(GameObjects.CappiSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Cappi));
        GetUI<Button>(GameObjects.BazziSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Bazzi));
        GetUI<Button>(GameObjects.MaridSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Marid));
        GetUI<Button>(GameObjects.BazziSelect.ToString()).Select();
    }

    private void Start()
    {
        //roomController = GetComponentInChildren<RoomUserController>();
        //Debug.LogError(roomController.photonView.ViewID);
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject go = PhotonNetwork.InstantiateRoomObject("UI_UserList", transform.position, transform.rotation);
            roomController = go.GetComponentInChildren<RoomUserController>();
            Debug.LogError(roomController + "Master");
        }
        else
        {
            roomController = GameObject.Find("UserList").GetComponentInChildren<RoomUserController>();
            Debug.LogError(roomController + "No");
        }
    }


    public void SetRoomInfo(RoomEntity roomInfo)
    {
        GetUI<TMP_Text>(GameObjects.RoomNumber.ToString()).text = roomInfo.RoomNum.ToString("D3");
        GetUI<TMP_Text>(GameObjects.RoomName.ToString()).text = roomInfo.RoomName;
    }

    //MaxPlayer 에 따라 X 되어있는 자리.

    public void ExitRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void SelectCharacter(Define.Characters character)
    {
        roomController.CharacterChange(character);
    }

    public void GameStart()
    {
        Manager.Game.GamePlayers = roomController.Players;
        Debug.Log($"게임 참가 플레이어 수 : {Manager.Game.GamePlayers.Count}");
        //씬 로드
    }
}
