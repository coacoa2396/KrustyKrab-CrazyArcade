using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CreateRoom : PopUpUI
{
    private string[] roomNameList =
    {
        "즐거운 게임해요","매너겜 필수"
    };

    enum GameObjects
    {
        CreateButton,
        CloseButton,
        RoomNameInput,
        MaxPlayerInput
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.CreateButton.ToString()).onClick.AddListener(CreateRoom);
        GetUI<Button>(GameObjects.CloseButton.ToString()).onClick.AddListener(Manager.UI.ClearPopUpUI);
    }


    public void CreateRoom()
    {
        string roomName = GetUI<TMP_InputField>(GameObjects.RoomNameInput.ToString()).text;
        string maxPlayerStr = GetUI<TMP_InputField>(GameObjects.RoomNameInput.ToString()).text;

        if (roomName == "")
            roomName = roomNameList[Random.Range(0, roomNameList.Length)];

        int maxPlayer = maxPlayerStr == "" ? 8 : int.Parse(maxPlayerStr);
        maxPlayer = Mathf.Clamp(maxPlayer, 1, 8);

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = maxPlayer;
        PhotonNetwork.CreateRoom(roomName, options);
    }


}
