using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;
using Photon.Pun;

public class BreakableWall : BaseWall, IBreakable
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tile>())
        {
            this.tileNode = collision.GetComponent<Tile>().tileNode;
        }

        if (collision.GetComponent<Stream>())
        {
            //권새롬 추가 --> 마스터 클라이언트 기준으로 벽돌 파괴하기
            if(PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(gameObject);
                ItemSpawner.Inst.SpawnItem(transform.position);
            }
        }
    }
}
