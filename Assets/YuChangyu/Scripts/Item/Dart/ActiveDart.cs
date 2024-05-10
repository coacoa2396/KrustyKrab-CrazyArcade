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

    int useNumber;

    public override void Use()
    {
        Fire();
    }

    public void Fire()
    {
        Vector3 shootVec = Player.playerInputHandler.MoveDir;
        
        switch ((shootVec.x, shootVec.y, shootVec.z))
        {
            case (-1, 0, 0):
                Instantiate(left);
                break;
            case (0, 0, 1):
                Instantiate(up);
                break;
            case (1, 0, 0):
                Instantiate(right);
                break;
            case (0, 0, -1):
                Instantiate(down);
                break;
            default:
                break;
        }
    }
}
