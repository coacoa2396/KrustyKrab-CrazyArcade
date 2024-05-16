using Firebase.Database;
using System;
using System.Threading;
using UnityEngine;

[Serializable]
public class UserEntity
{
    public string key;
    public string nickName;
    public bool isConnect;
    public float exp;
    public float maxExp;
    public int level;

    public UserEntity(string key, string nickName,int level)
    {
        this.key = key;
        this.nickName = nickName;
        this.exp = 0;
        this.level = level;
        this.maxExp = Define.MAX_EXP[level-1];
        isConnect = false;
    }


    public void SetConnect(bool isConnect)
    {
        this.isConnect = isConnect;
    }
}

