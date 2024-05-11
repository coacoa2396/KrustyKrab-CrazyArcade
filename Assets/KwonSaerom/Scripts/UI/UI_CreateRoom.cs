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
        if (Time.timeScale < 0.1f)
            Time.timeScale = 1;
        base.Awake();
        GetUI<Button>(GameObjects.CreateButton.ToString()).onClick.AddListener(CreateRoom);
        GetUI<Button>(GameObjects.CloseButton.ToString()).onClick.AddListener(Manager.UI.ClearPopUpUI);
        GetUI<TMP_InputField>(GameObjects.RoomNameInput.ToString()).text = roomNameList[Random.Range(0, roomNameList.Length)];
    }


    public void CreateRoom()
    {
        string roomName = GetUI<TMP_InputField>(GameObjects.RoomNameInput.ToString()).text;
        string maxPlayerStr = GetUI<TMP_InputField>(GameObjects.MaxPlayerInput.ToString()).text;

        if (roomName == "")
            roomName = roomNameList[Random.Range(0, roomNameList.Length)];

        int maxPlayer = maxPlayerStr == "" ? 8 : int.Parse(maxPlayerStr);
        maxPlayer = Mathf.Clamp(maxPlayer, 1, 8);

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = maxPlayer;
        if(Time.timeScale < 0.1f)
            Time.timeScale = 1;
        PhotonNetwork.CreateRoom(roomName, options);
    }


}
