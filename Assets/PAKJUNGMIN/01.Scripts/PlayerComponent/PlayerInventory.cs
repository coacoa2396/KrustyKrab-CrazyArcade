using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    PlayerMediator playerMediator;
    [SerializeField] List<GameObject> inven;


    public List<GameObject> Inven
    {
        get
        {
            return inven;
        }
    }

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();

        if(inven != null) { inven = null; }
        inven = new List<GameObject>();
    }



}
