using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_RoomToken : BaseUI
{
    private RoomEntity roomInfo;
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

    }

    public void OffActive()
    {
        roomInfo = null;
        gameObject.SetActive(false);
    }

    public void SetRoomInfo(RoomEntity room)
    {
        roomInfo = room;
        gameObject.SetActive(true);
        GetUI<TMP_Text>(GameObjects.RoomName.ToString()).text = room.RoomName;
        GetUI<TMP_Text>(GameObjects.RoomNumber.ToString()).text = room.RoomNum.ToString("D3");
        GetUI<TMP_Text>(GameObjects.MaxNum.ToString()).text = room.MaxPlayer.ToString();
    }

    public void EnterRoom()
    {
        string key = $"{roomInfo.RoomNum}/{roomInfo.RoomName}";
        LobbyManager.NowRoom = roomInfo;
        PhotonNetwork.JoinRoom(key);
    }
}
