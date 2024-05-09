using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템의 베이스 세팅
/// </summary>
public class Item : MonoBehaviour
{
    [Header("LayerMask")]
    [SerializeField] LayerMask playerCheck;         // 트리거에서 플레이어를 체크 할 레이어마스크
    [SerializeField] LayerMask waterCourseCheck;           // 물줄기 체크

    public bool CheckPlayer(GameObject gameObject)
    {
        if (playerCheck.Contain(gameObject.layer))
            return true;

        return false;
    }

    public bool CheckWater(GameObject gameObject)
    {
        if (waterCourseCheck.Contain(gameObject.layer))
            return true;

        return false;
    }
}
