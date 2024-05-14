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

    public string RoomName { get { return roomName; } }
    public int RoomNum { get { return roomNum; } }
    public int MaxPlayer { get { return maxPlayer; } }

    public RoomEntity(string roomName,int roomNum,int maxPlayer)
    {
        this.roomName = roomName;
        this.roomNum = roomNum;
        this.maxPlayer = maxPlayer;
    }

    public RoomEntity(RoomInfo info)
    {
        string[] s = info.Name.Split("/");
        roomName = s[1];
        roomNum = int.Parse(s[0]);
        maxPlayer = info.MaxPlayers;
    }

    public string Serialize()
    {
        return $"{roomName}/{roomNum}/{maxPlayer}";
    }

    public void DeSrialize(string code)
    {
        string[] token = code.Split('/');

        Debug.Log(code);
        Debug.Log($"{token[0]} {token[1]} {token[2]}");
        roomName = token[0];
        roomNum = int.Parse(token[1]);
        maxPlayer = int.Parse(token[2]);
    }
}
