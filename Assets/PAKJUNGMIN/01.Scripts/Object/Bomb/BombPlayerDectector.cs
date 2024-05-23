using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class : 폭탄 입장에서 플레이어를 감지하는 콜라이더 관리
/// </summary>
public class BombPlayerDectector : MonoBehaviour
{
    [SerializeField] BoxCollider2D playercollider;
    public bool IsActive;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStreamDectector>())
        {
            playercollider.enabled = true;
            IsActive = true;
        }
    }
    private void OnDisable()
    {
        playercollider.enabled = false;
        IsActive = false;
    }
}
