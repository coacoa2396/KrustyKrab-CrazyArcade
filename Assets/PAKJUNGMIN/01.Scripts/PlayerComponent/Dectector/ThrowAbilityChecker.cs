using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAbilityChecker : MonoBehaviour
{
    PlayerMediator playerMediator;




    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.GetComponent<BombTileCalculator>())
        {
            playerMediator.playerSkill.canThrow = true;
           // playerMediator.playerSkill.canKick = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BombTileCalculator>())
        {
            playerMediator.playerSkill.canThrow =false;
            //playerMediator.playerSkill.canKick = false;
        }
    }
}
