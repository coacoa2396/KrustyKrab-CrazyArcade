using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin
{
    // Scriptable Object : 스크럽터블 오브젝트로 캐릭터별 스텟 저장
    [CreateAssetMenu(fileName = "CharactorStats", menuName = "PAKJUNGMIN_ScriptableObject/New_CharactorStats")]
    public class CharacterStats : ScriptableObject
    {

        [Header("초기 이동속도")]
        public float initSpeed;
        [Header("최대 이동속도")]
        public float maxSpeed;


        [Header("초기 물줄기 파워")]
        public int initPower;
        [Header("최대 물줄기 파워")]
        public int maxPower;


        [Header("초기 물풍선 개수")]
        public int initBomb;
        [Header("최대 물풍선 개수")]
        public int maxBomb;
    }


}
