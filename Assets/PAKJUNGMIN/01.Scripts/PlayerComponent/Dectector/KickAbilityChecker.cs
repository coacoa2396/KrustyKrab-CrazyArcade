using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickAbilityChecker : MonoBehaviour
{
    PlayerMediator playerMediator;
    public Bomb targetBomb;
    

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BombPlayerDectector>())
        {
            playerMediator.playerAbility.canKick = true;
            targetBomb = collision.transform.parent.GetComponent<Bomb>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BombPlayerDectector>())
        {
            playerMediator.playerAbility.canKick = false;

            targetBomb = null;
        }
    }
}
