using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterBombCollider : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("asfdasdf");
        if (collision.gameObject.GetComponent<Drift>())
        {
            Debug.Log("물폭탄 연쇄 작용");
            GetComponentInParent<WaterBomb>().Explode();
        }
    }
}
