using pakjungmin;
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

    [Header("Component")]
    [SerializeField] PlayerMediator player;            // 스탯을 올려줄 플레이어

    [Header("Spec")]
    [SerializeField] int waterProof;        // 방수기능

    public PlayerMediator Player { get { return player; } set { player = value; } }
    public int WaterProof { get { return waterProof; } set { waterProof = value; } }

    private void Start()
    {
        waterProof = 1;
    }

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
