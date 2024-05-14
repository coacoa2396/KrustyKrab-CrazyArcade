using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class : 폭탄 설치 시 플레이어가 폭탄 통과가능, 콜라이더를 나갔을 때는 이동 불가.
/// </summary>
public class Bomb_Player_Detector : MonoBehaviour
{
    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if ((gameObject.layer << collision.gameObject.layer) != 0)
        //{
            boxCollider.enabled = false;
        //}
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCollider>())
        {
            boxCollider.enabled = true;
        }
    }

}
