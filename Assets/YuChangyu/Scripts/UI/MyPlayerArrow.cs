using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerArrow : MonoBehaviour
{
    [SerializeField] float offset;
    PlayerPhotonContoller player;

    private void Start()
    {
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(players.Length);
        //PlayerPhotonContoller[] _players = new PlayerPhotonContoller[players.Length];
        //for (int i = 0; i < players.Length; i++)
        //{
        //    Debug.LogError(players[i]);
        //    _players[i] = players[i].GetComponent<PlayerPhotonContoller>();
        //    Debug.LogError("_players" + _players[i]);
        //}

        //foreach (PlayerPhotonContoller player in _players)
        //{
        //    if (!player.PV.IsMine)
        //        continue;

        //    this.player = player;
        //    break;
        //}
    }

    private void LateUpdate()
    {
        if(player == null)
        {
            if (Manager.Game.PlayerGameObject == null)
                return;
            player = Manager.Game.PlayerGameObject.GetComponent<PlayerPhotonContoller>();
        }
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offset , player.transform.position.z);
    }
}
