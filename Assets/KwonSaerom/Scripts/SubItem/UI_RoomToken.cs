using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_RoomToken : BaseUI
{
    private bool isActive = false;
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
        isActive = false;
        gameObject.SetActive(false);
    }

    public void SetRoomInfo(RoomEntity room)
    {
        isActive = true;
        gameObject.SetActive(true);
        GetUI<TMP_Text>(GameObjects.RoomName.ToString()).text = room.RoomName;
        GetUI<TMP_Text>(GameObjects.RoomNumber.ToString()).text = room.RoomNum.ToString("D3");
        GetUI<TMP_Text>(GameObjects.MaxNum.ToString()).text = room.MaxPlayer.ToString();
    }

    public void EnterRoom()
    {

    }
}
