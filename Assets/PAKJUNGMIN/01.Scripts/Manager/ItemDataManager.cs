using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : Singleton<ItemDataManager>
{
    [SerializeField] Dictionary<GameObject, string> itemDir = new Dictionary<GameObject, string>();


    private void Start()
    {
        GameObject[] array = Resources.LoadAll<GameObject>("Prefabs/Item");

        foreach (GameObject x in array)
        {
            IAcquirable acquirable = x.GetComponent<IAcquirable>();
            if (acquirable != null)
            {
                itemDir.Add(x, $"{x.name}");
                Debug.Log($"아이템 딕셔너리 크기 : {itemDir.Count}");
                Debug.Log($"{x.name}이 아이템 딕셔너리에 추가됨");
            }
        }
    }



}
