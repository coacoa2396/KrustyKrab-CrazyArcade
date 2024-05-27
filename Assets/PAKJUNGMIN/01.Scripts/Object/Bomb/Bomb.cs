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

        [SerializeField] public TileNode tileNode;
        public int PosX { get { return tileNode.posX; } set { tileNode.posX = value; } }
        public int PosY { get { return tileNode.posY; } set { tileNode.posY = value; } }


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
                CommandExplode();
            }
        }
        private void OnEnable()
        {
            StartExplodeCoroutine();
            Manager.Sound.PlaySFX("PlantBomb");
        }
        private void OnDisable()
        {
            ownTime = defaultTime;
            PosX = 0;
            PosY = 0;
        }
        public void StopExplodeCoroutine()
        {
            StopCoroutine(explodeCoroutine);
        }
        public void StartExplodeCoroutine()
        {
            explodeCoroutine = StartCoroutine(WaitExplode());

        }
        public void CommandExplode()
        {
            GetComponentInChildren<ExplodeHandler>().Explode(bombPower);
        }
    }
}