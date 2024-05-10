using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어의 모든 
    /// </summary>
    public class PlayerMediator : MonoBehaviour
    {
        public PlayerBehavior playerBehavior; //플레이어의 행동.
        public PlayerInputHandler playerInputHandler; //캐릭터 인풋 시스템 
        public CharacterStats characterStats; // 캐릭터별 스텟 데이터 스크럽터블 오브젝트
        public PlayerStats playerStats; //플레이어의 현재 스텟
        public PlayerState playerState; // 플레이어의 현재 상태 -> 유찬규 추가 내용
        public FloorChecker floorChecker;
        public WaterBomb prefab;

        ActiveBase curActiveItem;   // 플레이어의 현재 액티브아이템 -> 유찬규 추가 내용
        public ActiveBase CurActiveItem { get { return curActiveItem; } set { curActiveItem = value; } }

        public void InputMove(Vector3 moveDir)
        {
            playerBehavior.Move(moveDir);
        }
        public void InputPlant() { playerBehavior.Plant(prefab, floorChecker.nowTile.transform.position); }
        public void InputUse() { playerBehavior.Use(); }
    }
}
