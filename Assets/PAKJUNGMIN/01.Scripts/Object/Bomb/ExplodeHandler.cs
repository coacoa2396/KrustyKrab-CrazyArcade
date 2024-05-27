using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ExplodeHandler : MonoBehaviour
{

    public void Explode(int power)
    {

        int posX = GetComponentInParent<Bomb>().PosX;
        int posY = GetComponentInParent<Bomb>().PosY;

        Manager.Sound.PlaySFX("BoomBomb");

        StreamManager.Stream.CalculateStream(posX, posY, power);
        GetComponentInParent<Bomb>().Release();
    }
}
