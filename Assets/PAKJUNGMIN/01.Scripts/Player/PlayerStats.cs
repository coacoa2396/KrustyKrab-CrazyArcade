using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] PlayerMediator playerMediator;

        OwnStats ownStats;

        public float Speed { get { return ownStats.speedValue; } set { ownStats.speedValue = value; } }
        public float Bomb { get { return ownStats.bombValue; } set { ownStats.bombValue = value; } }
        public float Power { get { return ownStats.powerValue; } set { ownStats.powerValue = value; } }

        void Awake()
        {
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
        public float bombValue;
        public float powerValue;
    }
}
