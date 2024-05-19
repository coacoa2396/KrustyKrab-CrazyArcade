using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Class : 폭탄 입장에서 물줄기로 인한 연쇄 반응 혹은, 날아오는 다트 감지.
/// </summary>
public class BombCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Stream>())
        {
            try //나중에 정확한 로직을 써서 바꿀것. 예외 처리 사용지양. 0513 메모
            {
                GetComponentInParent<Bomb>().CommandExplode();
            }
            catch
            {
                return;
            }
        }

    }
}
