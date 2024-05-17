using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Class : 플레이어에게 부여된 능력 혹은 상태이상
/// </summary>
public class PlayerAbility : MonoBehaviour
{
    PlayerMediator playerMediator;
    //능력 여부 
    public bool onRide;
    public bool canThrow;
    public bool canKick;
    //던지기와 킥이 둘다 가능할때 던지기만 하도록 조정해야한다.
    public bool firstIsThrow;

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }
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
        if (!playerMediator.playerInventory.Inven.Exists((gameObject_ => gameObject_.GetComponent<Glove>()))) {
            //Debug.Log("글러브 없음");
            return; 
        }

        if(canThrow)
        {
            //Debug.Log("폭탄 던지기!!");
        }
        
    }
    /// <summary>
    /// Method : 플레이어가 물풍선을 차는 능력. --> 물풍선이 플레이어의 앞에 있을 경우에만 작동
    /// </summary>
    public void Kick()
    {
        if (!canKick) { return; }
        if (!playerMediator.playerInventory.Inven.Exists((gameObject_ => gameObject_.GetComponent<Shoes>())))
        {
            Debug.Log("신발 없음");
            return;
        }




    }
    

}
