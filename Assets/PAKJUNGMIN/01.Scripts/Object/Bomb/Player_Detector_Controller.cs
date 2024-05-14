using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detector_Controller : MonoBehaviour
{
     BoxCollider2D playercollider;

    private void Awake()
    {
        playercollider = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerCollider>())
        {
            Debug.Log("콜라이더 On");
            playercollider.enabled = true;
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<PlayerCollider>())
    //    {

    //    }
    //}

}
