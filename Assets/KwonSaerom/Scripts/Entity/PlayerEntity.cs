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

    public UserEntity User { get { return user; } set { user = value; } }
    public Characters Character { get { return character; }set { character = value; } }
    public string Key { get { return key; } }

    public PlayerEntity(UserEntity entity, Characters character)
    {
        user = entity;
        key = entity.key;
        this.character = character;
    }

    public PlayerEntity(UserEntity entity)
    {
        user = entity;
        key = entity.key;
        character = Characters.Bazzi;
    }
}
