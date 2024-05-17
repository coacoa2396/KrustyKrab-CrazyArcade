using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    static ItemManager instance;

    public static ItemManager ItemData { get { return instance; } }

    public Dictionary<string,GameObject> itemDir = new Dictionary<string, GameObject>();


    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this as ItemManager;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        GameObject[] array = Resources.LoadAll<GameObject>("Prefabs/Item");

        foreach (GameObject x in array)
        {

            IAcquirable acquirable = x.GetComponent<IAcquirable>();
            if (acquirable != null)
            {
                itemDir.Add($"{x.name}", x);
            }
        }

    }
}
