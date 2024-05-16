using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : Singleton<ItemDataManager>
{
    static ItemDataManager instance;

    public static ItemDataManager ItemData { get { return instance; } }

    public Dictionary<string,GameObject> itemDir = new Dictionary<string, GameObject>();

   
    private void Awake()
    {
        if(instance != null) { instance = null; }
        instance = this;


        GameObject[] array = Resources.LoadAll<GameObject>("Prefabs/Item");

        foreach (GameObject x in array)
        {
            IAcquirable acquirable = x.GetComponent<IAcquirable>();
            if (acquirable != null)
            {
                itemDir.Add($"{x.name}",x);
            }
        }
    }



}
