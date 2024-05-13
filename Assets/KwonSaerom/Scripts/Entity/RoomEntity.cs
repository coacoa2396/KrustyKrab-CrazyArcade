using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntity
{
    private string roomName;
    private int roomNum;
    private int maxPlayer;

    public string RoomName { get { return roomName; } }
    public int RoomNum { get { return roomNum; } }
    public int MaxPlayer { get { return maxPlayer; } }

    public RoomEntity(string roomName,int roomNum,int maxPlayer)
    {
        this.roomName = roomName;
        this.roomNum = roomNum;
        this.maxPlayer = maxPlayer;
    }
}
