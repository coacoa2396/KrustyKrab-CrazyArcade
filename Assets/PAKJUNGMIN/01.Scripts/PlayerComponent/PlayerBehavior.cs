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
        /// Method : 플레이어 폭탄 설치 컨트롤러에 폭탄 설치를 명령하는 메소드.
        /// </summary>
        /// <param name="waterBomb"></param>
        /// <param name="BombPos"></param>
        public void Plant(PooledObject waterBomb,Vector3 BombPos)
        {
            playerMediator.playerBombPlantController.OnPlant(waterBomb, BombPos);
        }

        public void Use()
        {
            playerMediator.CurActiveItem?.Use();     // 플레이어가 현재 들고있는 액티브아이템을 사용 -> 유찬규 추가
        }
    }
}
