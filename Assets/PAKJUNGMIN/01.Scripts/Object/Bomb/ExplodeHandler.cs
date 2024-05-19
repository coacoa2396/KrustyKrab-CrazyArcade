using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeHandler : MonoBehaviour
{
    [SerializeField] BombTileCalculator bombtilePos;
    public void Explode(int power)
    {
        if (GetComponentInParent<Bomb>().GetComponentInChildren<BombTileCalculator>())
        {
           int posX = GetComponentInParent<Bomb>().PosX;
           int posY = GetComponentInParent<Bomb>().PosY;

            StreamManager.Stream.CalculateStream(posX, posY, power);
            GetComponentInParent<Bomb>().Release();
        }
    }
}
