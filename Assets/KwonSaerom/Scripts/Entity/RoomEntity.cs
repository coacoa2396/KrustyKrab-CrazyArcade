using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntity
{
    private string roomName;
    private int roomNum;
    private int maxPlayer;
    private int nowPlayer;
    private Define.Maps map;
    public string RoomName { get { return roomName; } }
    public int RoomNum { get { return roomNum; } }
    public int MaxPlayer { get { return maxPlayer; } }
    public int NowPlayer { get { return nowPlayer; } set { nowPlayer = value; } }
    public Define.Maps Map
    {
        get { return map; }
        set { map = value; }
    }

    public RoomEntity(string roomName,int roomNum,int maxPlayer)
    {
        this.roomName = roomName;
        this.roomNum = roomNum;
        this.maxPlayer = maxPlayer;
        nowPlayer = 1;
    }

    public RoomEntity(RoomInfo info)
    {
        string[] s = info.Name.Split("/");
        roomName = s[1];
        roomNum = int.Parse(s[0]);
        maxPlayer = info.MaxPlayers;
        nowPlayer = info.PlayerCount;
    }

    public void UpdateRoomInfo(string name,int maxPlayer)
    {
        roomName = name;
        this.maxPlayer = maxPlayer;

    }
}
