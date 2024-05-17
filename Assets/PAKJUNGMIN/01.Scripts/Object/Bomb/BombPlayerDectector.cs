using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class : 폭탄 입장에서 플레이어를 감지하는 콜라이더 관리
/// </summary>
public class BombPlayerDectector : MonoBehaviour
{
     BoxCollider2D playercollider;

    private void Awake()
    {
        playercollider = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStreamDectector>())
        {
            //Debug.Log("콜라이더 On");
            playercollider.enabled = true;
        }
    }

}
