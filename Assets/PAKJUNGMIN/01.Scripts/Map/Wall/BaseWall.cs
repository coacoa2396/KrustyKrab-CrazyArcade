using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseWall : MonoBehaviour
{
    public TileNode tileNode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tile>())
        {
            this.tileNode = collision.GetComponent<Tile>().tileNode;
        }
    }

}
