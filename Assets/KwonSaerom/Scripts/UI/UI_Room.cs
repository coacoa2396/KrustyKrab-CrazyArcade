using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Define;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class UI_Room : PopUpUI
{
    [SerializeField] List<Sprite> mapImages;
    [SerializeField] UI_WarningRoom warningPopup;
    [SerializeField] UI_SelectMap selectMap;
    [SerializeField] UI_RoomInfoChange roomInfoChangePopup;

    RoomUserController roomController;

    enum GameObjects
    {
        SelectMapButton,
        GameStartButton,
        RoomInfoChangeButton,
        RoomName,
        RoomNumber,
        ExitButton,
        DaoSelect,
        CappiSelect,
        BazziSelect,
        MaridSelect,
        MapImage
    }


    protected override void Awake()
    {
        base.Awake();
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        GetUI<Button>(GameObjects.ExitButton.ToString()).onClick.AddListener(ExitRoom);
        GetUI<Button>(GameObjects.SelectMapButton.ToString()).onClick.AddListener(SelectMapClick);
        GetUI<Button>(GameObjects.RoomInfoChangeButton.ToString()).onClick.AddListener(RoomChangeClick);
        GetUI<Button>(GameObjects.DaoSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Dao));
        GetUI<Button>(GameObjects.CappiSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Cappi));
        GetUI<Button>(GameObjects.BazziSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Bazzi));
        GetUI<Button>(GameObjects.MaridSelect.ToString()).onClick.AddListener(()=> SelectCharacter(Define.Characters.Marid));
        GetUI<Button>(GameObjects.BazziSelect.ToString()).Select();
    }

    private void OnEnable()
    {
        Manager.Game.OnChangeMap += ChangeMapImage;
    }

    private void OnDisable()
    {
        Manager.Game.OnChangeMap -= ChangeMapImage;
    }

    private void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GameObject go = PhotonNetwork.InstantiateRoomObject("UI_UserList", transform.position, transform.rotation);
            roomController = go.GetComponentInChildren<RoomUserController>();
        }
        else
        {
            roomController = GameObject.Find("UserList").GetComponentInChildren<RoomUserController>();
        }
        GetUI<Button>(GameObjects.GameStartButton.ToString()).onClick.AddListener(GameStart);
        Manager.Game.MapType = (Define.Maps)PhotonNetwork.CurrentRoom.CustomProperties["Map"];
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

    public void RoomChangeClick()
    {
        UI_RoomInfoChange popup = Instantiate(roomInfoChangePopup);
        popup.SetRoom(this);
    }

    public void RoomChange()
    {
        SetRoomInfo(LobbyManager.NowRoom);
        roomController.InitMaxPlayer();
    }

    public void GameStart()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if(roomController.IsStart())
            {
                Manager.Game.GamePlayers = roomController.GetNowPlayerList();
                Debug.Log($"게임 참가 플레이어 수 : {Manager.Game.GamePlayers.Count}");
                PhotonNetwork.CurrentRoom.IsOpen = false;
                PhotonNetwork.CurrentRoom.IsVisible = false;
                if (Manager.Game.MapType == Maps.BlockMap)
                    roomController.GameStart("VillageScene");
            }
            else
            {
                UI_WarningRoom warning = Instantiate(warningPopup);
                warning.SetLog("플레이어가 한명이거나, 플레이어가 모두 레디하기 전까지는 시작할 수 없습니다.");
            }
        }
        else
        {
            //토글
            bool readyInfo = !Manager.Game.Player.IsReady;
            Manager.Game.Player.IsReady = readyInfo;
            roomController.ReadyChange(readyInfo);
        }
    }

    public void SelectMapClick()
    {
        if (PhotonNetwork.IsMasterClient == false)
            return;
        UI_SelectMap selectUI = Instantiate(selectMap);
        selectUI.SetRoom(this);
    }

    public void ChangeMapImage()
    {
        GetUI<Image>(GameObjects.MapImage.ToString()).sprite = mapImages[(int)Manager.Game.MapType];
    }

    public void SelectMapConfirm()
    {
        //프로퍼티 바꾸기
        Hashtable ht = PhotonNetwork.CurrentRoom.CustomProperties;
        ht["Map"] = Manager.Game.MapType;
        PhotonNetwork.CurrentRoom.SetCustomProperties(ht);

        roomController.MapChage(Manager.Game.MapType);
    }
}
