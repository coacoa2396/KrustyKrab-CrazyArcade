using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace pakjungmin
{
    public class PlayerInputHandler : MonoBehaviour
    {
        PlayerMediator playerMediator;
        Vector3 moveDir;

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
