using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
    public class WaterBomb : PooledObject
    {
        //물풍선의 소유권. 즉 설치한 플레이어의 정보 필드 구현 필요.
        PlayerMediator playerMediator;
        //설치된 곳의 타일의 좌표 필요.
        Tile locatePos;
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
            //gameObject.transform.position = locatePos.transform.position;
            //waterCoursePower = (int)playerMediator.playerStats.Power;
            explodeCoroutine = StartCoroutine(WaitExplode());

        }
        private void OnDisable()
        {
            explodeTime = 4;
        }
        void Explode()
        {
            Locatedrift();
            gameObject.SetActive(false);
        }
        void Locatedrift()
        {
            //물줄기의 범위 계산 루틴.
            
        }
    }
}