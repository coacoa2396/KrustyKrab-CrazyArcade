using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
    public class WaterBomb : PooledObject
    {
        //물풍선의 소유권. 즉 설치한 플레이어의 정보 필드 구현 필요.
        //PlayerMediator playerMediator;

        //물풍선 폭파되기까지 시간.
        [SerializeField] float explodeTime;


        //물줄기의 파워
        int waterCoursePower;

        Coroutine explodeCoroutine;

        /// <summary>
        /// Coroutine : 물풍선의 폭파 대기 시간 구현.
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitExplode()
        {
            //폭파 시간 루틴 구현 필요
            while (true)
            {
                explodeTime -= Time.deltaTime;
                yield return null;
                if (explodeTime <= 0) {
                    break;
                   
                }
            }
            if (explodeTime <= 0) { Explode();}
        }

        private void OnEnable()
        {
            if(!GetComponentInChildren<BombLocator>()) { 
                return;
            }
            //int power = playerMediator.playerStats.Power;
            explodeCoroutine = StartCoroutine(WaitExplode());
        }


        private void OnDisable()
        {
            explodeTime = 4;
        }

        public void Explode()
        {
            int posX = GetComponentInChildren<BombLocator>().PosX;
            int posY = GetComponentInChildren<BombLocator>().PosY;
            //int power = playerMediator.playerStats.Power;
            gameObject.SetActive(false);
            DriftManager.Drift.LocateDrift(posX, posY,3);
        }
    }
}