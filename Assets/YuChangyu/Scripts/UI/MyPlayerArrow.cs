using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerArrow : MonoBehaviour
{
    [SerializeField] PlayerPhotonContoller player;

    [SerializeField] float offset;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        PlayerPhotonContoller[] _players = new PlayerPhotonContoller[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            _players[i] = players[i].GetComponent<PlayerPhotonContoller>();
        }

        foreach (PlayerPhotonContoller player in _players)
        {
            if (!player.PV.IsMine)
                continue;

            this.player = player;
            break;
        }
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset , player.transform.position.z);
    }
}
