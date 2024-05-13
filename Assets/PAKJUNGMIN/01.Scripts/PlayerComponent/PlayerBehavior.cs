using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin 
{

    public class PlayerBehavior : MonoBehaviour
    {
        PlayerMediator playerMediator;
        Vector2 moveDir;

        private void Awake()
        {
            playerMediator = GetComponent<PlayerMediator>();
            
        }
        private void FixedUpdate()
        {       
            gameObject.transform.Translate(moveDir * playerMediator.playerStats.Speed * Time.deltaTime, Space.World);
        }

        public void Move(Vector3 moveDir)
        {
            PlayerStats stat = playerMediator.playerStats;

            if (moveDir.x == 0 || moveDir.z == 0)
            {
                this.moveDir.x = moveDir.x;
                this.moveDir.y = moveDir.z;

            }
        }

        /// <summary>
        /// 플레이어의 물풍선 설치 행동
        /// </summary>
        public void Plant(PooledObject waterBomb,Vector3 BombPos)
        {
            //플레이어가 물풍선 프리팹과 물풍선이 놓일 좌표를 알고 있어야함.
            Manager.Pool.GetPool(waterBomb,BombPos, Quaternion.identity);
        }
        /// <summary>
        /// 액티브 아이템 사용
        /// </summary>
        public void Use()
        {
            playerMediator.CurActiveItem?.Use();     // 플레이어가 현재 들고있는 액티브아이템을 사용 -> 유찬규 추가
        }
    }
}
