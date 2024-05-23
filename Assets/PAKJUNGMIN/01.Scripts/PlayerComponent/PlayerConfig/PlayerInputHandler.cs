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
    public class PlayerInputHandler : MonoBehaviourPun, IPunObservable
    {
        PlayerMediator playerMediator;
        public Vector3 moveDir;

        public Vector3 MoveDir { get { return moveDir; } } // 외부에서 확인 할 프로퍼티 -> 유찬규 추가

        private void Awake()
        {
            playerMediator = GetComponent<PlayerMediator>();
        }


        public void OnMove(InputValue value)
        {
            if (photonView.IsMine)
            {
                if (playerMediator.playerState.ownState != PlayerStateMachine.State.Devil)
                {
                    moveDir = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
                    playerMediator.InputMove(moveDir);
                }
                else
                {
                    moveDir = new Vector3(-value.Get<Vector2>().x, 0,-value.Get<Vector2>().y);
                    playerMediator.InputMove(moveDir);
                }
            }
        }

        public void OnPlant(InputValue value)
        {
            if (photonView.IsMine)
            {
                TileNode nowTile = playerMediator.GetNowTile();
                photonView.RPC("InputPlant", RpcTarget.All, nowTile.posX,nowTile.posY); //--> 권새롬 추가(물풍선이 모두 같은 위치에 놓여야함)
            }
        }

        public void OnUse(InputValue value)
        {
            if (photonView.IsMine)
            {
                photonView.RPC("InputUse", RpcTarget.All); //--> 권새롬 추가
            }
        }


        //--> 권새롬 추가
        [PunRPC]
        public void InputPlant(int posX,int posY)
        {
            playerMediator.InputPlant(posX,posY);
        }

        [PunRPC]
        public void InputUse()
        {
            playerMediator.InputUse();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if(stream.IsWriting)
            {
                stream.SendNext(moveDir);
            }
            else if(stream.IsReading)
            {
                moveDir = (Vector3)stream.ReceiveNext();
            }
        }
        //------
    }
}
