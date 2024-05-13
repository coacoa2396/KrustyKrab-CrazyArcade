using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
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
