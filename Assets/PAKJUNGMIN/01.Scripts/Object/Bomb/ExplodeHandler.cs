using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeHandler : MonoBehaviour
{

    public void Explode(int power)
    {
        if (GetComponentInParent<Bomb>().GetComponentInChildren<BombTileCalculator>())
        {
            int posX = GetComponentInParent<Bomb>().GetComponentInChildren<BombTileCalculator>().PosX;
            int posY = GetComponentInParent<Bomb>().GetComponentInChildren<BombTileCalculator>().PosY;


            StreamManager.Stream.CalculateStream(posX, posY, power);


            GetComponentInParent<Bomb>().Release();

            //GetComponentInParent<Bomb>().gameObject.SetActive(false); //---->0,0이 되는 오류

        }
    }
}
