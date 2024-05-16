using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Define;
public class PlayerEntity
{
    private UserEntity user;
    private string key;
    private Characters character;
    private bool isReady;

    public UserEntity User { get { return user; } set { user = value; } }
    public Characters Character { get { return character; }set { character = value; } }
    public string Key { get { return key; } }
    public bool IsReady { get { return isReady; } set { isReady = value; } }

    public PlayerEntity(UserEntity entity, Characters character,bool isReady)
    {
        user = entity;
        key = entity.key;
        this.character = character;
        this.isReady = isReady;
    }

    public PlayerEntity(UserEntity entity)
    {
        user = entity;
        key = entity.key;
        character = Characters.Bazzi;
        isReady = false;
    }
}
