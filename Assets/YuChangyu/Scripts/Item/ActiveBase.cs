using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 액티브아이템의 베이스
/// </summary>
public class ActiveBase : MonoBehaviour
{
    [SerializeField] PlayerMediator player;            // 플레이어

    string name;
    int useNumber;

    public PlayerMediator Player { get { return player; } set { player = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int UseNumber { get { return useNumber; } set { useNumber = value; } }

    public virtual void Use()
    {

    }

    public virtual void Init(PlayerMediator player)
    {
        this.player = player;
    }
}
