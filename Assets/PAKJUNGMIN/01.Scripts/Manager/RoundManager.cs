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
 *  작동방식 개괄

    0.게임에 참여한 모든 플레이어를 playerList에 삽입.이때 PlayerRoundData객체로 등록됨
      PlayerRoundData 객체에 Player GameObject 필드,승패여부 (outcome)필드 존재
      승패필드는 이 클래스의 열거형.

    1.현재 생존중인 플레이어를 SurvivorList에 삽입.

    2.모든 플레이어의 PlayerStateMachine.cs의 OnDie 필드에 PlayerDieEvent() 이벤트 등록.
      PlayerDieEvent()는 플레이어 사망 시 호출되는 이벤트 메소드. --> (플레이어가 상태 패턴이 Die()로 바뀌면 PlayerStateMachine.cs의 OnDie()  -> RoundManager의 PlayerDieEvent());

    3.CheckSurvivor()는 오직 PlayerDieEvent()가 호출될 때마다 호출됨. 

    4.CheckSurvivor가 호출되면, 우선 사망한 플레이어를 SurvivorList에서 제거하고,
      PlayerList을 순회하여 모든 플레이어의 사망 여부를 판단하여,
      사망한 플레이어의 PlayerRoundData.outcome 필드를 lose로, 생존한 플레이어는 Win으로 변경.

    5.CheckSurvivor에서 (SurvivorList.Count <= 1)이면 SetOutcome() 호출

    6. SetOutcome()는 PlayerList의 각각 PlayerRoundData의 outcome 필드를 확인하고, 
       우선 모든 PlayerRoundData의 outcome 필드가 win인 객체가 하나도 없었을 경우, outcome 필드를 모두 draw로 바꾼다.

       그 후 다시 한번 각각 PlayerRoundData의 outcome 필드를 다시 한번 순회하여,
       모든 객체의 결과값들을 Debug.Log로 반환한다.
       

*/
public class RoundManager : MonoBehaviour
{   
    static RoundManager instance;
    public static RoundManager Round { get { return instance; } }

    [SerializeField] List<PlayerRoundData> playerList; //게임에 참가한 모든 플레이어 리스트
    [SerializeField] List<GameObject> survivorList; //현재 살아남은 플레이어 리스트


    //****************************** 게임씬에서 로드 시 버그가 있기에, 잠시 
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
            }
            survivorList.Add(player);
            playerList.Add(new PlayerRoundData(player));
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

            Debug.Log($"{playerData.player.name} is {playerData.outcome}");
        
        }
    }
    public enum Outcome
    {
        Win,
        lose,
        draw
}

}
