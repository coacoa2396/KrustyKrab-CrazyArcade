using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pakjungmin
{
    public class Bomb : MonoBehaviour
    {
        //물풍선의 소유권. 즉 설치한 플레이어의 정보 필드 구현 필요.

        //설치된 곳의 타일 좌표 필드 구현 필요.

        //물풍선 폭파되기까지 시간.
        [SerializeField] float explodeTime;


        /// <summary>
        /// Coroutine : 물풍선의 폭파 대기 시간 구현.
        /// </summary>
        /// <returns></returns>
        IEnumerator WaitExplode()
        {
            //폭파 시간 루틴 구현 필요
            yield return null;
        }

        private void OnEnable()
        {
            //활성화 시 코루틴 시작 구현 필요
        }
        private void OnDisable()
        {
            //물줄기 생성 루틴 구현 필요.
        }
        void Explode()
        {

        }
    }
}