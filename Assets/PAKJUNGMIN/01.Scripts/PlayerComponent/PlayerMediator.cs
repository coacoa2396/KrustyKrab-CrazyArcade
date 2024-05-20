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

        [Header("플레이어의 앞방향을 가리키는 지침")]
        public ForwardGuide forwardGuide;

        [Header("플레이어의 스텟")]
        public CharacterStats characterStats; // 캐릭터별 스텟 데이터 스크럽터블 오브젝트
        public PlayerStats playerStats; //플레이어의 현재 스텟
        [Header("플레이어의 상태 및 애니메이션")]
        public PlayerStateMachine playerState; // 플레이어의 현재 상태 -> 유찬규 추가 내용
        public PlayerAnimationController playerAnimCon; // 플레이어 애니메이션 컨트롤러 -> 유찬규 추가 내용
        [Header("플레이어의 콜라이더 관련")]
        public PlayerTileCalculator playerTileCalculator;
        public PlayerBombPlantCalculator playerBombPlantCalculator;

        [Header("플레이어의 아이템 관련 ")]
        public PlayerInventory playerInventory;
        public Bomb bomb;
        [Header("플레이어의 스킬")]
        public PlayerAbility playerAbility;
        public ThrowAbilityChecker throwAbilityChecker;

        [Space(3f)]
        [Header("플레이어 인벤토리")]
        [SerializeField] ActiveBase curActiveItem;   // 플레이어의 현재 액티브아이템 -> 유찬규 추가 내용
        public ActiveBase CurActiveItem { get { return curActiveItem; } set { curActiveItem = value; } }

        public void InputMove(Vector3 moveDir)
        {
            if (playerAbility.canKick) { playerAbility.Kick(); }
            playerBehavior.Move(moveDir);
            SetForwardGuide(moveDir);
        }
        public void InputPlant()
        { 
            if (playerTileCalculator.nowTile != null)
            {
                playerBehavior.Plant(bomb, TileManager.Tile.tileDic[$"{playerTileCalculator.nowTile.tileNode.posX},{playerTileCalculator.nowTile.tileNode.posY}"]);
            }
        }
        
        public void InputUse() { playerBehavior.Use(); }

        void SetForwardGuide(Vector3 moveDir)
        {
            if(moveDir.x > 0 && moveDir.z == 0)
            {
                forwardGuide.ChangeForward(ForwardGuide.ForwardState.left);            
            }
            else if(moveDir.x < 0 && moveDir.z == 0)
            {
                forwardGuide.ChangeForward(ForwardGuide.ForwardState.right);
              
            }
            else if(moveDir.x == 0 && moveDir.z > 0)
            {
                forwardGuide.ChangeForward(ForwardGuide.ForwardState.up);
              
            }
            else if (moveDir.x == 0 && moveDir.z < 0)
            {
                forwardGuide.ChangeForward(ForwardGuide.ForwardState.down);
               
            }
        }
    }
}
