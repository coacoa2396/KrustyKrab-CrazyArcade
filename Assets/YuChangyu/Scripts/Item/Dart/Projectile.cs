using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템 : Dart 사용 시 날라가는 투사체
/// </summary>
public class Projectile : MonoBehaviour
{
    [Header ("Component")]
    [SerializeField] Rigidbody rigid;

    [Header("LayerMask")]
    [SerializeField] LayerMask bombCheck;

    [Header ("Spec")]
    [SerializeField] string shootVec;       // up, right, down, left
    [SerializeField] float speed;           // 투사체의 속도

    private void Start()
    {
        switch (shootVec)
        {
            case "up":
                rigid.velocity = Vector3.up * speed;
                break;
            case "right":
                rigid.velocity = Vector3.right * speed;
                break;
            case "down":
                rigid.velocity = Vector3.down * speed;
                break;
            case "left":
                rigid.velocity = Vector3.left * speed;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (bombCheck.Contain(collision.gameObject.layer))
        {
            WaterBomb bomb = collision.gameObject.GetComponent<WaterBomb>();
            
        }
    }
}
