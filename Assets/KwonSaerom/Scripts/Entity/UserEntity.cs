using Firebase.Database;
using System;
using System.Threading;
using UnityEngine;

[Serializable]
public class UserEntity
{
    public string key;
    public string nickName;
    public int isConnect; //bool 계속 잘못받아와서 --> 1 : 연결됨 / 나머지 숫자 : 연결안됨
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
        isConnect = 0;
    }


    public void SetConnect(int isConnect)
    {
        this.isConnect = isConnect;
    }
}

