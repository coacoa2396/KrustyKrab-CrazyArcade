using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class UI_RoomInfoChange : MonoBehaviour
{
    [SerializeField] UI_WarningRoom warningPopup;
    [SerializeField] Button updateButton;
    [SerializeField] Button closeButton;
    [SerializeField] TMP_InputField roomNameInput;
    [SerializeField] TMP_InputField maxPlayerInput;
    UI_Room connectRoom;

    private void Awake()
    {
        updateButton.onClick.AddListener(UpdateRoom);
        closeButton.onClick.AddListener(Close);
        roomNameInput.text = LobbyManager.NowRoom.RoomName;
        maxPlayerInput.text = LobbyManager.NowRoom.MaxPlayer.ToString();
    }


    public void UpdateRoom()
    {
        string roomName = roomNameInput.text;
        string maxPlayerStr = maxPlayerInput.text;

        if (roomName.Contains('/'))
        {
            UI_WarningRoom warning = Instantiate(warningPopup);
            warning.SetLog("제목에 '/' 는 들어갈 수 없습니다.");
            return;
        }

        if (roomName == "")
        {
            UI_WarningRoom warning = Instantiate(warningPopup);
            warning.SetLog("공백은 입력할 수 없습니다");
            return;
        }


        int maxPlayer = maxPlayerStr == "" ? 8 : int.Parse(maxPlayerStr);
        maxPlayer = Mathf.Clamp(maxPlayer, LobbyManager.NowRoom.NowPlayer, 8);

        if (Time.timeScale < 0.1f)
            Time.timeScale = 1;

        LobbyManager.NowRoom.UpdateRoomInfo(roomName, maxPlayer);
        PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "RoomName", roomName } });
        PhotonNetwork.CurrentRoom.MaxPlayers = maxPlayer;
        connectRoom.RoomChange();
        Close();
    }

    public void SetRoom(UI_Room room)
    {
        connectRoom = room;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
