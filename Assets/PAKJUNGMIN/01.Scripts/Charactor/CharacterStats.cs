using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin
{
    // Scriptable Object : 스크럽터블 오브젝트로 캐릭터별 스텟 저장
    [CreateAssetMenu(fileName = "CharactorStats", menuName = "PAKJUNGMIN_ScriptableObject/New_CharactorStats")]
    public class CharacterStats : ScriptableObject
    {

        [Header("캐릭터의 이동속도")]
        [SerializeField] float speed;
        [Header("캐릭터의 물풍선 파워")]
        [SerializeField] float powerValue;
        [Header("캐릭터의 초기 물풍선 개수")]
        [SerializeField] float bombValue;


        public float Speed { get { return speed; } }
        public float Power { get { return powerValue; } }
        public float Bomb { get { return bombValue; } }
    }


}
