using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_RoomToken : BaseUI
{
    [SerializeField] UI_Warning warningPopup;
    private RoomEntity roomInfo;
    private bool isActive;

    public bool IsActive { get { return isActive; } }
    
    enum GameObjects
    {
        RoomNumber,
        RoomName,
        MaxNum,
        NowNum,
        MapImage,
        EnterButton
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.EnterButton.ToString()).onClick.AddListener(EnterRoom);
        isActive = false;
    }

    public void OffActive()
    {
        roomInfo = null;
        gameObject.SetActive(false);
        isActive = false;
    }

    public void SetRoomInfo(RoomEntity room)
    {
        roomInfo = room;

        isActive = true;
        gameObject.SetActive(true);
        GetUI<TMP_Text>(GameObjects.RoomName.ToString()).text = room.RoomName;
        GetUI<TMP_Text>(GameObjects.RoomNumber.ToString()).text = room.RoomNum.ToString("D3");
        GetUI<TMP_Text>(GameObjects.MaxNum.ToString()).text = room.MaxPlayer.ToString();
        GetUI<TMP_Text>(GameObjects.NowNum.ToString()).text = room.NowPlayer.ToString();
    }

    public void EnterRoom()
    {
        string key = $"{roomInfo.RoomNum}/{roomInfo.RoomName}";
        LobbyManager.NowRoom = roomInfo;
        if (roomInfo.NowPlayer == roomInfo.MaxPlayer)
        {
            UI_Warning warning = Manager.UI.ShowPopUpUI(warningPopup);
            warning.SetLog("방에 입장할 수 없습니다.");
        }else
        {
            PhotonNetwork.JoinRoom(key);
        }
    }
}
