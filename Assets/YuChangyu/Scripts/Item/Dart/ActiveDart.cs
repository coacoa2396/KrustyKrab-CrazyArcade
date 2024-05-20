using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ForwardGuide;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : Dart의 액티브기능
/// </summary>
public class ActiveDart : ActiveBase
{
    [SerializeField] Projectile up;
    [SerializeField] Projectile down;
    [SerializeField] Projectile right;
    [SerializeField] Projectile left;

    bool checkUse;

    public override void Use()
    {
        if (!checkUse)
        {
            checkUse = true;
            Fire();
            checkUse = false;
        }
    }

    public void Fire()
    {
        switch (Player.forwardGuide.Forward)
        {
            case ForwardState.left:
                Instantiate(right, Player.forwardGuide.transform.position, Quaternion.identity);
                Debug.Log("좌 생성");
                break;
            case ForwardState.up:
                Instantiate(up, Player.forwardGuide.transform.position, Quaternion.identity);
                Debug.Log("상 생성");
                break;
            case ForwardState.right:
                Instantiate(left, Player.forwardGuide.transform.position, Quaternion.identity);
                Debug.Log("우 생성");
                break;
            case ForwardState.down:
                Instantiate(down, Player.forwardGuide.transform.position, Quaternion.identity);
                Debug.Log("하 생성");
                break;
            default:
                Debug.Log("생성안됨");
                break;
        }

        UseNumber--;

        if (UseNumber == 0)
            Player.CurActiveItem = null;
    }

    public override void Init(PlayerMediator player)
    {
        base.Init(player);
        Name = "Dart";
        UseNumber = 3;
    }
}
