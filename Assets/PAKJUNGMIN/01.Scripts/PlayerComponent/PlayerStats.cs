using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어 캐릭터의 현재 스탯
    /// </summary>
    public class PlayerStats : MonoBehaviour
    {
        PlayerMediator playerMediator;

        [SerializeField] OwnStats ownStats;

        public float Speed { get { return ownStats.speedValue; } set { ownStats.speedValue = value; } }
        public int Bomb { get { return ownStats.bombValue; } set { ownStats.bombValue = value; } }
        public int Power { get { return ownStats.powerValue; } set { ownStats.powerValue = value; } }


        void Awake()
        {
            playerMediator = GetComponentInParent<PlayerMediator>();
            InitSet();
        }

        //Method : 미리 설정한 캐릭터 스탯 스크럽터블 오브젝트의 값을 현재 캐릭터 스탯(구조체)에 복사한다.
        void InitSet()
        {
            ownStats.powerValue = playerMediator.characterStats.Power;
            ownStats.speedValue = playerMediator.characterStats.Speed;
            ownStats.bombValue = playerMediator.characterStats.Bomb;
        }
    }


    [Serializable]
    public struct OwnStats
    {
        public float speedValue;
        public int bombValue;
        public int powerValue;
    }
}
