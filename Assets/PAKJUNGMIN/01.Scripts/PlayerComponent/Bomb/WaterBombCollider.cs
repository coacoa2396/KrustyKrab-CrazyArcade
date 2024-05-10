using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterBombCollider : MonoBehaviour
{
    //물풍선을 놓았을 때, 콜라이더를 끄고 다시 켜는 로직 구현 필요

    CircleCollider2D circleCollider;


    private void OnEnable()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("Exit human");
    //    circleCollider.enabled = true;
    //}
}
