using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSpawnController : MonoBehaviour
{
    static ItemSpawnController instance;

    List<GameObject> randomitemList;

    public static ItemSpawnController Inst {  get { return instance; } }

    private void Awake()
    {
        if(instance != null) { instance = null; }
        instance = this;
    }
    private void Start()
    {
        randomitemList = new List<GameObject>();

        Debug.Log($"1. {ItemDataManager.ItemData}");
        Debug.Log($"2. {ItemDataManager.ItemData.itemDir}");

        foreach (KeyValuePair<string,GameObject> itemData in ItemDataManager.ItemData.itemDir)
        {
            randomitemList.Add(itemData.Value);
        }
    }
    /// <summary>
    /// Method : 매개변수 좌표를 넣으면, 랜덤으로 아이템을 생성해준다. ---> 전반적으로 클래스 코드가 더럽다. 리팩토링 필요.
    /// </summary>
    /// <param name="tilePos"></param>
    public void SpawnItem(Vector3 tilePos)
    {
        if(randomitemList == null) { return; }
        int randomspawn = Random.Range(0, 10);
        Debug.Log($"r : {randomspawn}");
        if(randomspawn > 5)
        {
            Instantiate(randomitemList[Random.Range(0, randomitemList.Count)], tilePos, Quaternion.identity);
        }
    }
}
