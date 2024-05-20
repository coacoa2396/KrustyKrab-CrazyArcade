using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        Vector3 shootVec = Player.playerInputHandler.MoveDir;

        switch ((shootVec.x, shootVec.y, shootVec.z))
        {
            case (-1, 0, 0):
                Instantiate(left, transform.position, Quaternion.identity);
                break;
            case (0, 0, 1):
                Instantiate(up, transform.position, Quaternion.identity);
                break;
            case (1, 0, 0):
                Instantiate(right, transform.position, Quaternion.identity);
                break;
            case (0, 0, -1):
                Instantiate(down, transform.position, Quaternion.identity);
                break;
            default:
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
