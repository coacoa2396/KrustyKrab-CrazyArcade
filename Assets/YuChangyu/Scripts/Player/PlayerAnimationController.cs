using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 플레이어의 애니메이션을 컨트롤 하는 컴포넌트
/// </summary>
public class PlayerAnimationController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] PlayerMediator player;
    [SerializeField] Animator animator;

    [Header("variable")]
    [SerializeField] Vector2 checkIdle;

    private void Start()
    {
        player = GetComponent<PlayerMediator>();
        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        if (player.playerInputHandler.MoveDir == Vector3.zero)  // 조작이 없으면 아이들 상태로 바꾸고 리턴
        {
            switch ((checkIdle.x, checkIdle.y))
            {
                case (1, 0):
                    animator.SetTrigger("Right");
                    break;
                case (-1, 0):
                    animator.SetTrigger("Left");
                    break;
                case (0, 1):
                    animator.SetTrigger("Up");
                    break;
                case (0, -1):
                    animator.SetTrigger("Down");
                    break;
            }
            return;
        }

        checkIdle = Vector2.zero;

        if (player.playerInputHandler.MoveDir.x == 0)           // 좌우 조작이 없는 경우
        {
            if (player.playerInputHandler.MoveDir.z < 0)        // 아랫 방향 조작인 경우
            {
                animator.SetFloat("Y", -1);
                checkIdle = new Vector2(0, -1);
            }
            else                                                // 윗 방향 조작인 경우
            {
                animator.SetFloat("Y", 1);
                checkIdle = new Vector2(0, 1);
            }
        }
        else if (player.playerInputHandler.MoveDir.z == 0)      // 상하 조작이 없는 경우
        {
            if (player.playerInputHandler.MoveDir.x < 0)        // 좌 방향 조작인 경우
            {
                animator.SetFloat("X", -1);
                checkIdle = new Vector2(-1, 0);
            }
            else                                                // 우 방향 조작인 경우
            {
                animator.SetFloat("X", 1);
                checkIdle = new Vector2(1, 0);
            }
        }
    }
}
