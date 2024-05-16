using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace pakjungmin
{
    public class Bomb : PooledObject
    {
        [Header("물풍선 폭파 시간")]
        [SerializeField] float defaultTime;
        [SerializeField] float ownTime;

        //물줄기의 파워
        public int bombPower;

        Coroutine explodeCoroutine;

        // Coroutine : 물풍선의 폭파 대기 시간 구현.
        IEnumerator WaitExplode()
        {
            //폭파 시간 루틴 구현 필요
            while (true)
            {
                ownTime -= Time.deltaTime;
                yield return null;
                if (ownTime <= 0) {
                    break;                
                }
            }
            if (ownTime <= 0)
            {
                Explode();
            }
        }
        private void Start()
        {
            
        }
        private void OnEnable()
        {
            if(!GetComponentInChildren<BombTileCalculator>()) { 
                return;
            }
            explodeCoroutine = StartCoroutine(WaitExplode());
        }
        private void OnDisable()
        {
            ownTime = defaultTime;

        }

        //**가끔가다가 pos가 0,0이 되어버리는 원인이 이곳인것 같다.
        public void Explode()
        {
            Debug.Log($"GetComponentInChildren<BombTileCalculator>().PosX : {GetComponentInChildren<BombTileCalculator>().PosX}");
            Debug.Log($"GetComponentInChildren<BombTileCalculator>().PosY : {GetComponentInChildren<BombTileCalculator>().PosY}");
            int posX = GetComponentInChildren<BombTileCalculator>().PosX;
            int posY = GetComponentInChildren<BombTileCalculator>().PosY;
            StreamManager.Stream.CaculateStreamPos(posX, posY, bombPower);
            gameObject.SetActive(false);
            //코루틴 시간 차를 이용해, 순서가 꼬여 
            //플레이어의 물폭탄 파워와, 물폭탄의 파워가 안되던 버그가 해결되었지만
            //나중에 고쳐야한다.
        }
    }
}