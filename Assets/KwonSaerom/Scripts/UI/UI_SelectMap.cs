using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class UI_SelectMap : MonoBehaviour
{
    [SerializeField] Button confirmButton;
    [SerializeField] Button closeButton;
    [SerializeField] Button blockMap;
    [SerializeField] Button desertMap;

    UI_Room nowRoomUI;
    Maps selectedMap;

    enum GameObjects
    {
        ConfirmButton,
        CloseButton,
        BlockMap,
        DesertMap
    }

    private void Awake()
    {
        selectedMap = Manager.Game.MapType;
        confirmButton.onClick.AddListener(ConfirmClick);
        closeButton.onClick.AddListener(Close);
        blockMap.onClick.AddListener(() => SelectMap(Maps.BlockMap));
        desertMap.onClick.AddListener(() => SelectMap(Maps.DesertMap));
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
        Close();
    }

    public void Close()
    {
        Destroy(gameObject);
    }

}
