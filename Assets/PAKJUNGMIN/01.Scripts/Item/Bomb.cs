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
            yield return null;
        }

        private void OnEnable()
        {

        }
        /// <summary>
        /// 물풍선의 기폭.
        /// </summary>
        void Explode()
        {

        }
    }
}