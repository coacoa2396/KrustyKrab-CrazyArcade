using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room : PopUpUI
{
    enum GameObjects
    {
        SelectMapButton,
        GameStartButton,
        RoomName,
        RoomNumber,
        ExitButton
    }


    protected override void Awake()
    {
        base.Awake();
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        GetUI<Button>(GameObjects.ExitButton.ToString()).onClick.AddListener(ExitRoom);
    }


    public void SetRoomInfo(RoomEntity roomInfo)
    {
        GetUI<TMP_Text>(GameObjects.RoomNumber.ToString()).text = roomInfo.RoomNum.ToString("D3");
        GetUI<TMP_Text>(GameObjects.RoomName.ToString()).text = roomInfo.RoomName;
    }

    //MaxPlayer 에 따라 X 되어있는 자리.

    public void ExitRoom()
    {
        Close();
        PhotonNetwork.LeaveRoom();
    }
}
