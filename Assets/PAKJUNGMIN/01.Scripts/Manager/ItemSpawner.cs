using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSpawner : MonoBehaviour
{
    static ItemSpawner instance;

    [Header("아이템이 나올 확률 변수: 10에 가까울 수록 확률 높아짐")]
    [SerializeField] int randomNumber;

    [SerializeField] List<string> randomitemList;
    private string[] itemPath = { "Dart","Needle","Shield"};

    public static ItemSpawner Inst {  get { return instance; } }

    private void Awake()
    {
        if(instance != null) { instance = null; }
        instance = this;
    }
    private void Start()
    {
        randomitemList = new List<string>();

        foreach (KeyValuePair<string,GameObject> itemData in ItemManager.ItemData.itemDir)
        {
            randomitemList.Add(itemData.Key);
        }
    }
    /// <summary>
    /// Method : 매개변수 좌표를 넣으면, 랜덤으로 아이템을 생성해준다. ---> 전반적으로 클래스 코드가 더럽다. 리팩토링 필요.
    /// </summary>
    /// <param name="tilePos"></param>
    public void SpawnItem(Vector3 tilePos)
    {
        if(randomitemList == null) { return; }

        int randomnumber_ = Random.Range(0, 10);
        if(randomNumber >= randomnumber_)
        {
            int R = Random.Range(0, randomitemList.Count);

            GameObject itemGo = PhotonNetwork.InstantiateRoomObject($"Prefabs/Item/{randomitemList[R]}", tilePos, Quaternion.identity);
            foreach(string path in itemPath)
            {
                if (itemGo != null)
                    break;
                itemGo = PhotonNetwork.InstantiateRoomObject($"Prefabs/Item/Active/{path}/{randomitemList[R]}", tilePos, Quaternion.identity);
            }
            itemGo.SetActive(true);
        }
    }
}
