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

    float time;
    Coroutine coroutine;
    bool checkRoutine;

    private void Start()
    {
        player = GetComponent<PlayerMediator>();
        animator = GetComponent<Animator>();
        time = 0;
    }

    private void Update()
    {
        if (!(player.playerState.ownState == PlayerStateMachine.State.Trapped))
        {
            time = 0;
            return;
        }        
    }

    private void LateUpdate()
    {
        if (player.playerState.ownState == PlayerStateMachine.State.Alive)
        {
            if (player.playerInputHandler.MoveDir == Vector3.zero)  // 조작이 없으면 아이들 상태로 바꾸고 리턴
            {
                animator.SetFloat("X", 0);
                animator.SetFloat("Y", 0);
                animator.SetBool("Walk", false);
                if (checkRoutine == false)
                {
                    coroutine = StartCoroutine(CheckAFK());
                    checkRoutine = true;
                }

                switch ((checkIdle.x, checkIdle.y))
                {
                    case (1, 0):
                        animator.SetBool("Right", true);
                        break;
                    case (-1, 0):
                        animator.SetBool("Left", true);
                        break;
                    case (0, 1):
                        animator.SetBool("Up", true);
                        break;
                    case (0, -1):
                        animator.SetBool("Down", true);
                        break;
                }
                return;
            }

            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("AFK", false);
            StopCoroutine(coroutine);
            checkRoutine = false;

            checkIdle = Vector2.zero;

            if (player.playerInputHandler.MoveDir.x == 0)           // 좌우 조작이 없는 경우
            {
                animator.SetFloat("X", 0);
                if (player.playerInputHandler.MoveDir.z == -1)        // 아랫 방향 조작인 경우
                {
                    animator.SetFloat("Y", -1);
                    checkIdle = new Vector2(0, -1);
                }
                else if (player.playerInputHandler.MoveDir.z == 1)    // 윗 방향 조작인 경우
                {
                    animator.SetFloat("Y", 1);
                    checkIdle = new Vector2(0, 1);
                }
                else
                {
                    checkIdle = Vector2.zero;
                }
            }
            else if (player.playerInputHandler.MoveDir.z == 0)      // 상하 조작이 없는 경우
            {
                animator.SetFloat("Y", 0);
                if (player.playerInputHandler.MoveDir.x == -1)        // 좌 방향 조작인 경우
                {
                    animator.SetFloat("X", -1);
                    checkIdle = new Vector2(-1, 0);
                }
                else if (player.playerInputHandler.MoveDir.x == 1)    // 우 방향 조작인 경우
                {
                    animator.SetFloat("X", 1);
                    checkIdle = new Vector2(1, 0);
                }
                else
                {
                    checkIdle = Vector2.zero;
                }
            }

            if (checkIdle.x == -1 || checkIdle.x == 1 || checkIdle.y == -1 || checkIdle.y == 1)
            {
                animator.SetBool("Walk", true);
            }
        }
        else if (player.playerState.ownState == PlayerStateMachine.State.Trapped)
        {
            animator.SetTrigger("Trap");

            time += Time.deltaTime;

            if (time > 4f)
                time = 4f;

            animator.SetFloat("TrapTime", time);
        }
        else if (player.playerState.ownState == PlayerStateMachine.State.Die)
        {
            animator.SetTrigger("Die");
        }
    }

    IEnumerator CheckAFK()
    {
        yield return new WaitForSeconds(5f);
        animator.SetBool("AFK", true);
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
    }
}
