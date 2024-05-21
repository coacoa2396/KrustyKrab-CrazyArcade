using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Class : 라운드 매니저
/// </summary>
/// 

/*
    Start 시 개괄
    
    0.모든 플레이어를 라운드 매니저의 playerList에 삽입.
    1.모든 플레이어의 PlayerStateMachine.cs의 OnDie 필드에 PlayerDieEvent() 이벤트 등록.
    
    작동 방식 개괄
    
    0.플레이어가 상태 패턴이 Die()로 바뀌면
    1.PlayerStateMachine.cs의 OnDie()  -> RoundManager의 PlayerDieEvent() ->  CheckSurvivor();
    2.이 때 PlayerList.Count가 1보다 작거나 같다면, 즉 생존한 플레이어가 0이거나 한명뿐이라면
    3.CheckSurvivor() -> ShowOutcome(); 으로 승패 판정.

*/
public class RoundManager : MonoBehaviour
{   
    static RoundManager instance;
    public static RoundManager Round { get { return instance; } }

    List<GameObject> playerList;

    public List<GameObject> PlayerList { get { return playerList; } }


    private void Awake()
    {
        if(instance != null) { Destroy(gameObject); }

        instance = this;
    }
    private void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
        Debug.Log($"playerList.Count : {playerList.Count}");
        foreach(GameObject player in playerList)
        {
            if(player.GetComponentInChildren<PlayerStateMachine>() == null) { continue; }
            player.GetComponentInChildren<PlayerStateMachine>().OnDied += PlayerDieEvent;

            if (player.GetComponentInChildren<PlayerStateMachine>().OnDied != null)
            {
                Debug.Log("사망 이벤트 함수 추가됨");
            }
        }

    }

    //Method : 생존한 플레이어의 인원수 체크
    void CheckSurvivor()
    {
        foreach (GameObject player in playerList)
        {
            if(!player.activeSelf)
            {
                playerList.Remove(player);
            }
            if(playerList.Count <= 1)
            {
                ShowOutcome();
                return;
            }
        }

    }
    void PlayerDieEvent()
    {
        Debug.Log("플레이어 사망");
        CheckSurvivor();

    }
    /// <summary>
    /// Method : Win,Lose,Draw 여부 계산. 플레이어마다 다르게 작용.
    /// </summary>
    void ShowOutcome()
    {
        List<GameObject> survivorList = new List<GameObject>();
        foreach(GameObject player in playerList)
        {
            if(player.activeSelf == true) { survivorList.Add(player); }
        }      
        if(survivorList.Count <= 0) { return; }

        if(survivorList.Count == 1 ) { Debug.Log($"{survivorList[0]} is win."); }

        else if(survivorList.Count > 1) { Debug.Log($"Draw"); }

    }

}
