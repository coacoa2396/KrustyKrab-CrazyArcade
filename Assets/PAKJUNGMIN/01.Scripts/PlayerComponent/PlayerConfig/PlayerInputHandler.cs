using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace pakjungmin
{
    /// <summary>
    /// Class : 플레이어 인풋 시스템 이벤트를 받는 클래스
    /// </summary>
    public class PlayerInputHandler : MonoBehaviourPun,IPunObservable
    {
        PlayerMediator playerMediator;
        Vector3 moveDir;

        public Vector3 MoveDir { get { return moveDir; } } // 외부에서 확인 할 프로퍼티 -> 유찬규 추가


        private bool canPlant,canUse; //--> 권새롬 추가

        private void Awake()
        {
            playerMediator = GetComponent<PlayerMediator>();
        }

        //권새롬 추가
        private void Update()
        {
            if (photonView.IsMine)
                return;
            if(canPlant)
            {
                playerMediator.InputPlant();
                canPlant = false;
            }
            if (canUse)
            {
                playerMediator.InputUse();
                canUse = false;
            }
            playerMediator.InputMove(moveDir);
        }

        public void OnMove(InputValue value)
        {
            if(photonView.IsMine)
            {
                moveDir = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
                playerMediator.InputMove(moveDir);
            }
        }

        public void OnPlant(InputValue value)
        {
            if (photonView.IsMine)
            {
                playerMediator.InputPlant();
                canPlant = true;
            }
        }
        public void OnUse(InputValue value)
        {
            if (photonView.IsMine)
            {
                playerMediator.InputUse();
                canUse = true;
            }
        }


        //권새롬 추가
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if(stream.IsWriting)
            {
                stream.SendNext(canPlant);
                stream.SendNext(canUse);
                stream.SendNext(moveDir);
            }
            else
            {
                canPlant = (bool)stream.ReceiveNext();
                canUse = (bool)stream.ReceiveNext();
                moveDir = (Vector3)stream.ReceiveNext();
            }
        }
    }
}
