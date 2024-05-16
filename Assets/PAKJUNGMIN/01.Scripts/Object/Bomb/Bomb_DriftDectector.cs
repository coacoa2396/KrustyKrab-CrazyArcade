using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Class : 물줄기로 인한 연쇄 반응 혹은, 날아오는 다트 감지.
/// </summary>
public class Bomb_DriftDectector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { //자식에 서로 콜라이더가 붙어있을 경우, 자식 콜라이더에 들어와도 부모 콜라이더에 들어온 것으로
        //인식된다. 이를 방지하려면, 부모와 자식 서로에 RigidBody 컴포넌트가 필요하다.
        if (collision.gameObject.GetComponent<Stream>())
        {
            try //나중에 정확한 로직을 써서 바꿀것. 예외 처리 사용지양. 0513 메모
            {
                GetComponentInParent<Bomb>().Explode();
            }
            catch
            {
                return;
            }
        }

    }
}
