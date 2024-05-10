using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어 인풋 시스템 이벤트를 받는 클래스
    /// </summary>
    public class PlayerInputHandler : MonoBehaviour
    {
        PlayerMediator playerMediator;
        Vector3 moveDir;

        public Vector3 MoveDir { get { return moveDir; } } // 외부에서 확인 할 프로퍼티 -> 유찬규 추가

        private void Awake()
        {
            playerMediator = GetComponent<PlayerMediator>();
        }

        public void OnMove(InputValue value)
        {
            moveDir = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
            playerMediator.InputMove(moveDir);
        }

        public void OnPlant(InputValue value)
        {
            playerMediator.InputPlant();
        }
        public void OnUse(InputValue value)
        {
            playerMediator.InputUse();
        }


    }
}
