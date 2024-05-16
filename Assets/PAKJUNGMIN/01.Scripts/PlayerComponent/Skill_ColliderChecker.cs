using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ColliderChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<BombLocator>())
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BombLocator>())
        {

        }
    }
}
