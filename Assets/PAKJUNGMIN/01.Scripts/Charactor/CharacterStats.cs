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
        [Header("캐릭터의 초기 물줄기 파워")]
        [SerializeField] int powerValue;
        [Header("캐릭터의 최대 물줄기 파워")]
        [SerializeField] int maxPowerValue;
        [Header("캐릭터의 초기 물풍선 개수")]
        [SerializeField] int bombValue;
        [Header("캐릭터의 최대 물풍선 개수")]
        [SerializeField] int maxBombValue;


        public float Speed { get { return speed; } }
        public int Power { get { return powerValue; } }
        public int Bomb { get { return bombValue; } }
        public int Maxbomb { get { return maxBombValue; } }
        public int MaxPower { get { return maxPowerValue; } }
    }


}
