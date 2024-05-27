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
            gameObject.SetActive(false);
            ItemSpawner.Inst.SpawnItem(transform.position);
        }
    }
}
