using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detector_Controller : MonoBehaviour
{
    [Header("플레이어 통과 여부 콜라이더")]
    [SerializeField] BoxCollider2D playercollider;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
