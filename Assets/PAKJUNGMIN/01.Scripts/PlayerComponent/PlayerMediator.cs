using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어 오브젝트 중재자
    /// </summary>
    public class PlayerMediator : MonoBehaviour
    {
        [Header("플레이어의 행동 관련")]
        public PlayerBehavior playerBehavior; //플레이어의 행동.
        public PlayerInputHandler playerInputHandler; //캐릭터 인풋 시스템 
        [Header("플레이어의 스텟")]
        public CharacterStats characterStats; // 캐릭터별 스텟 데이터 스크럽터블 오브젝트
        public PlayerStats playerStats; //플레이어의 현재 스텟
        [Header("플레이어의 상태 및 애니메이션")]
        public PlayerStateMachine playerState; // 플레이어의 현재 상태 -> 유찬규 추가 내용
        public PlayerAnimationController playerAnimCon; // 플레이어 애니메이션 컨트롤러 -> 유찬규 추가 내용
        [Header("플레이어의 콜라이더 관련")]
        public FloorChecker floorChecker;
        public BombPlantController playerBombPlantController;
        [Header("플레이어의 아이템 관련 ")]
        public PlayerInventory playerInventory;
        public Bomb bomb;
        [Header("플레이어의 스킬")]
        public PlayerSkill playerSkill;
        public Skill_ColliderChecker skill_ColliderChecker;
        [Space(3f)]
        [Header("플레이어 인벤토리")]
        [SerializeField] ActiveBase curActiveItem;   // 플레이어의 현재 액티브아이템 -> 유찬규 추가 내용
        public ActiveBase CurActiveItem { get { return curActiveItem; } set { curActiveItem = value; } }

        public void InputMove(Vector3 moveDir)
        {
            playerBehavior.Move(moveDir);
        }
        public void InputPlant() {
             //플레이어의 스킬에가 아니라 플레이어의 행동에서 하는 걸로 변경해야한다.
            if (floorChecker.nowTile.OnObject)
            {
                return;
            }

            playerBehavior.Plant(bomb, floorChecker.nowTile.transform.position); 
        }
        public void InputUse() { playerBehavior.Use(); }
    }
}
