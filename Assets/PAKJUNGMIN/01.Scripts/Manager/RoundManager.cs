using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEditor.Rendering;
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

    [SerializeField] List<PlayerRoundData> playerList; //게임에 참가한 모든 플레이어 리스트
    [SerializeField] List<GameObject> survivorList; //현재 살아남은 플레이어 리스트

    public enum Outcome
    {
        Win,
        lose,
        draw
    }

    //******************************
    IEnumerator TestLoad()
    {
        yield return new WaitForSeconds(5f);
        InitSetPlayer();
    }
    Coroutine ss;
    //****************************
    private void Awake()
    {
        if(instance != null) { Destroy(gameObject); }

        instance = this;
    }
    private void Start()
    {
        ss = StartCoroutine(TestLoad()); //************************************
    }

    void InitSetPlayer()
    {
        playerList = new List<PlayerRoundData>();
        GameObject[] playerArray = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in playerArray)
        {
            if (player.GetComponentInChildren<PlayerStateMachine>() == null) { continue; }
            player.GetComponentInChildren<PlayerStateMachine>().OnDied += PlayerDieEvent;
            if (player.GetComponentInChildren<PlayerStateMachine>().OnDied != null)
            {
                Debug.Log("사망 이벤트 함수 추가됨");
            }
            survivorList.Add(player);
            playerList.Add(new PlayerRoundData(player));
            Debug.Log($"playerList.Count : {playerList.Count}");
        }
    }


    //Method : 생존한 플레이어의 인원수 체크
    void CheckSurvivor()
    {
        foreach(PlayerRoundData playerData in playerList)
        {
            if (!survivorList.Contains(playerData.player))
            {
                playerData.outcome = Outcome.lose;
            }
            else
            {
                playerData.outcome = Outcome.Win;
            }
        }

        if (survivorList.Count <= 1)
        {
            SetOutcome();
            return;
        }

    }

    void PlayerDieEvent(PlayerStateMachine playerStateMachine)
    {
        GameObject playerobject = playerStateMachine.transform.parent.gameObject;
        if (survivorList.Contains(playerobject)) { survivorList.Remove(playerobject); }
        Debug.Log("플레이어 사망");
        CheckSurvivor();

    }

    /// <summary>
    /// Method : Win,Lose,Draw 여부 계산. 플레이어마다 다르게 작용.
    /// </summary>
    void SetOutcome()
    {
        if (!playerList.Exists(item => item.outcome == Outcome.Win)) // 살아남은 플레이어가 없었을 경우, 즉 무승부.
        {
            foreach (PlayerRoundData playerData in playerList)
            {
                playerData.outcome = Outcome.draw;
            }
            Debug.Log("Draw");
            return;
        }

        foreach (PlayerRoundData playerData in playerList)
        {

            Debug.Log($"{playerData.player.gameObject.name} is {playerData.outcome}");
        
        }
    }
}
