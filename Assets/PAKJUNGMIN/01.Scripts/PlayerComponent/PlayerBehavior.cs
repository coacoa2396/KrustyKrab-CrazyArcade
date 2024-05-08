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
        private void Update()
        {
            gameObject.transform.Translate(moveDir * playerMediator.playerStats.Speed * Time.deltaTime, Space.World);
        }

        public void Move(Vector3 moveDir)
        {
            PlayerStats stat = playerMediator.playerStats;
            this.moveDir.x = moveDir.x;
            this.moveDir.y = moveDir.z;
        }

        /// <summary>
        /// 플레이어의 물풍선 설치 행동
        /// </summary>
        public void Plant()
        {

        }
        /// <summary>
        /// 액티브 아이템 사용
        /// </summary>
        public void Use()
        {

        }
    }
}
