using pakjungmin;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 아이템의 베이스 세팅
/// </summary>
public class Item : MonoBehaviourPun
{
    [Header("LayerMask")]
    [SerializeField] LayerMask playerCheck;         // 트리거에서 플레이어를 체크 할 레이어마스크
    [SerializeField] LayerMask waterCourseCheck;           // 물줄기 체크

    [Header("Component")]
    [SerializeField] PlayerMediator player;            // 스탯을 올려줄 플레이어

    [Header("Spec")]
    [SerializeField] int waterProof;        // 방수기능

    public PlayerMediator Player { get { return player; } set { player = value; } }
    public int WaterProof { get { return waterProof; } set { waterProof = value; } }
    public GameObject[] players;

    private void Start()
    {
        waterProof = 1;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public bool CheckPlayer(GameObject gameObject)
    {
        if (playerCheck.Contain(gameObject.layer))
            return true;

        return false;
    }

    public bool CheckWater(GameObject gameObject)
    {
        if (waterCourseCheck.Contain(gameObject.layer))
            return true;

        return false;
    }

    //--- 권새롬 추가 네트워크에 active 정보를 전달
    public void SetActive(bool active)
    {
        photonView.RPC("SetActiveSend",RpcTarget.All,active);

    }

    [PunRPC]
    public void SetActiveSend(bool active)
    {
        gameObject.SetActive(active);
    }

    // 권새롬 추가 --> 인벤토리 동기화
    [PunRPC]
    public void AddInven(string item,int key)
    {
        if(players == null)
            players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            int playerOwnerId = player.GetComponent<PhotonView>().OwnerActorNr;
            if (playerOwnerId == key)
            {
                this.player = player.GetComponent<PlayerMediator>();
            }
        }
        Player.playerInventory.Inven.Add(ItemManager.ItemData.itemDir[item]);
        PrintInven();
    }

    private void PrintInven()
    {
        Debug.LogError($"{player.name} 인벤토리 ===========");
        foreach (GameObject itme in Player.playerInventory.Inven)
        {
            Debug.LogError($"{itme.name}");
        }
    }
}
