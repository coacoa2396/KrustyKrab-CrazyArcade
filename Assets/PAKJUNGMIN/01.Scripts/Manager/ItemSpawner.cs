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
    private ItemSpawner() { }

    public static ItemSpawner ItemSpawn { get{ return instance; } }

    [Header("아이템이 나올 확률 변수: 10에 가까울 수록 확률 높아짐")]
    [SerializeField] int randomNumber;

    [SerializeField] List<string> randomitemList;
    private string[] activeItemList = { "Dart","Needle","Shield"};

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
        if (PhotonNetwork.IsMasterClient == false) //마스터 클라이언트만 아이템을 생성할 수 있음. --> 권새롬 추가
            return;

        if(randomitemList == null) { return; }

        int randomnumber_ = Random.Range(0, 10);
        if(randomNumber >= randomnumber_)
        {
            int R = Random.Range(0, randomitemList.Count);

            // ---- 권새롬 추가
            GameObject itemGo = null;
            foreach (string activeItem in activeItemList)
            {
                if (activeItem.Equals(randomitemList[R]))
                    itemGo = PhotonNetwork.InstantiateRoomObject($"Prefabs/Item/Active/{activeItem}/{randomitemList[R]}", tilePos, Quaternion.identity);
            }
            if(itemGo == null)
                itemGo = PhotonNetwork.InstantiateRoomObject($"Prefabs/Item/{randomitemList[R]}", tilePos, Quaternion.identity);
            itemGo.GetComponent<Item>().SetActive(true);
            // ----
        }
    }

    public void ReleaseItem(List<GameObject> inven)
    {

        if (inven.Count < 1) { return; }
        List<Tile> SpawnList = new List<Tile>();

        foreach (KeyValuePair<string,Tile> tile in TileManager.Tile.tileDic)
        {
            if (tile.Value.onObject) { continue; }
            else if (!tile.Value.onObject)
            {
                SpawnList.Add(tile.Value);
            }
        }
        foreach (GameObject item in inven)
        {
            if (item.GetComponent<Item>() == null) { continue; }
            int randomIndex = Random.Range(0, SpawnList.Count-1);
            try
            {
                Instantiate(item, SpawnList[randomIndex].transform.position, Quaternion.identity);
                SpawnList.RemoveAt(randomIndex);
            }
            catch
            {

            }
        }

    }
}
