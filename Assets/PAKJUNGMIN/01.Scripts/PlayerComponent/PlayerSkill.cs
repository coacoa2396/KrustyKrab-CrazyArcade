using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Class : 플레이어에게 부여된 능력 혹은 상태이상
/// </summary>
public class PlayerSkill : MonoBehaviour
{

    //능력 여부 
    [SerializeField] bool onRide;
    [SerializeField] bool canThrow;
    [SerializeField] bool canKick;

    public bool OnRide { get { return onRide; } set { onRide = value; } }
    public bool CanThrow { get { return canThrow; } set { canThrow = value; } }
    public bool CanKick { get { return canKick; } set { canKick = value; } }


    /// <summary>
    /// Method : 플레이어가 탈 것을 탑승
    /// </summary>
    public void Ride()
    {

    }
    /// <summary>
    /// Method : 플레이어가 물풍선을 던지는 능력. --> 물풍선이 발 밑에 있을 경우만 작동
    /// </summary>
    public void Throw()
    {
        if (!canThrow) { return; }

    }
    /// <summary>
    /// Method : 플레이어가 물풍선을 차는 능력. --> 물풍선이 플레이어의 앞에 있을 경우에만 작동
    /// </summary>
    public void Kick()
    {
        if (!canKick) { return; }
        
    }
    

}
