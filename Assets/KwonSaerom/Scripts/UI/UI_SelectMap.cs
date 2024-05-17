using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UI_SelectMap : PopUpUI
{
    UI_Room nowRoomUI;
    Maps selectedMap;

    enum GameObjects
    {
        ConfirmButton,
        CloseButton,
        BlockMap,
        DesertMap
    }

    protected override void Awake()
    {
        base.Awake();
        selectedMap = Manager.Game.MapType;
        GetUI<Button>(GameObjects.ConfirmButton.ToString()).onClick.AddListener(ConfirmClick);
        GetUI<Button>(GameObjects.CloseButton.ToString()).onClick.AddListener(Close);
        GetUI<Button>(GameObjects.BlockMap.ToString()).onClick.AddListener(() => SelectMap(Maps.BlockMap));
        GetUI<Button>(GameObjects.DesertMap.ToString()).onClick.AddListener(() => SelectMap(Maps.DesertMap));
    }

    public void SetRoom(UI_Room room)
    {
        nowRoomUI = room;
    }

    public void SelectMap(Maps map)
    {
        selectedMap = map;
    }

    public void ConfirmClick()
    {
        Manager.Game.MapType = selectedMap;
        nowRoomUI.SelectMapConfirm();
    }

}
