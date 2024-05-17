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

        public float trapSpeed = 0.2f;
        public float aliveSpeed;
        public float dieSpeed = 0;

        //Property : 현재 플레이어의 스탯 값이 플레이어의 최대 스탯 값을 넘어가면 최대 스탯으로 강제 조정한다.
        public float OwnSpeed
        { 
            get { return ownStats.ownSpeed; } 
            set 
            { 
                ownStats.ownSpeed = value;
                if(ownStats.ownSpeed > ownStats.maxSpeed)
                {
                    ownStats.ownSpeed = ownStats.maxSpeed;
                }
            }
        }
        public int OwnBomb
        { 
            get { return ownStats.ownBomb; }
            set 
            {
                ownStats.ownBomb = value;
                if (ownStats.ownBomb > ownStats.maxBomb)
                {
                    ownStats.ownBomb = ownStats.maxBomb;
                }
            } 
        }
        public int OwnPower
        { 
            get { return ownStats.ownPower; }
            set 
            {
                ownStats.ownPower = value;
                if (ownStats.ownPower > ownStats.maxPower)
                {
                    ownStats.ownPower = ownStats.maxPower;
                }
            } 
        }

        void Awake()
        {
            playerMediator = GetComponentInParent<PlayerMediator>();
            InitSet();
        }

        //Method : 미리 설정한 캐릭터 스탯 스크럽터블 오브젝트의 값을 현재 캐릭터 스탯에 복사한다.
        void InitSet()
        {
            ownStats.ownPower = playerMediator.characterStats.initPower;
            ownStats.ownSpeed = playerMediator.characterStats.initSpeed;
            ownStats.ownBomb = playerMediator.characterStats.initBomb;

            ownStats.maxPower = playerMediator.characterStats.maxPower;
            ownStats.maxSpeed = playerMediator.characterStats.maxSpeed;
            ownStats.maxBomb = playerMediator.characterStats.maxBomb;
        }
    }


    [Serializable]
    public struct OwnStats
    {
        public float ownSpeed;
        public float maxSpeed;

        public int ownBomb;
        public int maxBomb;

        public int ownPower;
        public int maxPower;
    }
}
