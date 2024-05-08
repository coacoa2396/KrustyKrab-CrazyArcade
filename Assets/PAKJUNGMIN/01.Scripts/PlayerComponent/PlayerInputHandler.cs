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
