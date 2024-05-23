using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfoPrefab;

    private void Start()
    {
        int playerNum = RoundManager.Round.PlayerList.Count;

        for (int i = 0; i < playerNum; i++)
        {
            //Instantiate(playerInfoPrefab, );
        }
    }
}
