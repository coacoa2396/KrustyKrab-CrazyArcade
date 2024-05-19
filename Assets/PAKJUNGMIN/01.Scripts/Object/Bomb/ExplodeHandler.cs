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
            //int posX = GetComponentInParent<Bomb>().GetComponentInChildren<BombTileCalculator>().PosX;
            //int posY = GetComponentInParent<Bomb>().GetComponentInChildren<BombTileCalculator>().PosY;

            int posX = bombtilePos.GetComponent<BombTileCalculator>().PosX;
            int posY = bombtilePos.GetComponent<BombTileCalculator>().PosY;
            Debug.Log($"2. ExplodeHandler : {posX},{posY}");
            if (posX != 0 && posY != 0) { }
            else if(posX == 0 && posY == 0) { Debug.LogError("Explode에서 버그 발견!!"); }

            StreamManager.Stream.CalculateStream(posX, posY, power);
            GetComponentInParent<Bomb>().Release();
        }
    }
}
