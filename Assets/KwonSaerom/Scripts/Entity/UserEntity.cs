using System;
using System.Threading;
using UnityEngine;

[Serializable]
public class UserEntity : MonoBehaviour
{
    public string key;
    public string nickName;
    public bool isConnect;
    public float exp;
    public float maxExp;
    public int level;

    public UserEntity(string key,string nickName,float exp,float maxExp,int level)
    {
        this.key = key;
        this.nickName = nickName;
        this.exp = exp;
        this.maxExp = maxExp;
        this.level = level;
        SetConnect(true);
    }

    public UserEntity(string key, string nickName,int level)
    {
        this.key = key;
        this.nickName = nickName;
        this.exp = 0;
        this.level = level;
        this.maxExp = Define.MAX_EXP[level-1];
        SetConnect(true);
    }

    public void SetConnect(bool isConnect)
    {
        this.isConnect = isConnect;
    }
}

