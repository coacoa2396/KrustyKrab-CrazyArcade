using Firebase.Database;
using System;
using System.Threading;
using UnityEngine;

[Serializable]
public class UserEntity
{
    private string key;
    private string nickName;
    private bool isConnect;
    private float exp;
    private float maxExp;
    private int level;

    public string NickName { get { return nickName; } }
    public string Key { get { return key; } }

    public UserEntity(string key,string nickName,float exp,float maxExp,int level)
    {
        this.key = key;
        this.nickName = nickName;
        this.exp = exp;
        this.maxExp = maxExp;
        this.level = level;
        SetConnect(false);
    }

    public UserEntity(string key, string nickName,int level)
    {
        this.key = key;
        this.nickName = nickName;
        this.exp = 0;
        this.level = level;
        this.maxExp = Define.MAX_EXP[level-1];
        SetConnect(false);
    }

    public UserEntity(DataSnapshot snapshot)
    {
        key = (string)snapshot.Child("key").Value;
        nickName = (string)snapshot.Child("nickName").Value;
        exp = int.Parse(snapshot.Child("exp").Value.ToString());
        level = int.Parse(snapshot.Child("level").Value.ToString());
        maxExp = Define.MAX_EXP[level - 1];
        SetConnect(false);
    }

    public UserEntity(string json)
    {
        UserEntity user = JsonUtility.FromJson<UserEntity>(json);
        Debug.Log(user);
        SetConnect(false);
    }

    public void SetConnect(bool isConnect)
    {
        this.isConnect = isConnect;
    }
}

