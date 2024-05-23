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
            gameObject.transform.Translate(moveDir * playerMediator.playerStats.OwnSpeed * Time.deltaTime, Space.World);
        }

        public void Move(Vector3 moveDir)
        {
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
        public void Plant(Bomb waterBomb,Tile tile)
        {
            playerMediator.playerBombPlantCalculator.PlantBomb(waterBomb, TileManager.Tile.tileDic[$"{tile.tileNode.posX},{tile.tileNode.posY}"]);
        }
        public void Use()
        {
            playerMediator.CurActiveItem?.Use();     // 플레이어가 현재 들고있는 액티브아이템을 사용 -> 유찬규 추가
        }
    }
}
