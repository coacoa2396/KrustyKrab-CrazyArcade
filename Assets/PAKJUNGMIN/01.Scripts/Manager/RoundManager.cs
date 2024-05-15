using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class RoundManager : MonoBehaviour
{   
    static RoundManager instance;
    public static RoundManager Round { get { return instance; } }

    List<GameObject> playerList;

    private void Awake()
    {
        if(instance != null) { instance = null; }

        instance = this;

    }
    private void Start()
    {
        // ***** 지금 당장은 로비씬과 게임씬의 정보 교환이 어렵기에, Tag 사용 *******************
        playerList = GameObject.FindGameObjectsWithTag("Player").ToList<GameObject>();
    }


    /// <summary>
    /// Method :  라운드 시작 시 플레이어들을 정해진 시작 위치에 지정한다.
    /// </summary>
    void SetStartpos()
    {

    }


    // ****** 로비 씬에서 플레이어의 정보 및 플레이어의 수를 알아올 수 있다면 아래 코드 전부 삭제 *************


    /// <summary>
    /// Method : 생존한 플레이어 체크 -> 임시용. 바꿀 수 있음.
    /// </summary>
    void CheckSurvivor()
    {
        GameObject.FindGameObjectsWithTag("Player");

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
