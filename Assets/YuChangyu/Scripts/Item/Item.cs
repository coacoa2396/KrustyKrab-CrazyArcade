using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템의 베이스 세팅
/// </summary>
public class Item : MonoBehaviour
{
    [Header ("LayerMask")]
    [SerializeField] LayerMask playerCheck;         // 트리거에서 플레이어를 체크 할 레이어마스크
    [SerializeField] LayerMask waterCourseCheck;           // 물줄기 체크

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (waterCourseCheck.Contain(collision.gameObject.layer))         // 물줄기에 닿으면
        {
            Destroy(gameObject);                                    // 아이템 제거
            return;
        }

        if (!playerCheck.Contain(collision.gameObject.layer))       // 플레이어가 아니면
            return;                                                 // 리턴
    }


}
