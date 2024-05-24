using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규
/// 게임씬에서 사이드UI
/// </summary>
public class SideUI : MonoBehaviour
{
    [SerializeField] SidePlayerInfo prefab;

    private void Start()
    {
        StartCoroutine(CoInitSideUI());
    }

    public void InitSideUI()
    {
        if (RoundManager.Round == null)
        {
            Debug.LogError("Round is null");
        }

        if (RoundManager.Round.PlayerList == null)
        {
            Debug.LogError("PlayerList is null");
        }

        if (RoundManager.Round.PlayerList[0] == null)
        {
            Debug.LogError("PlayerList[0] is null");
        }

        int playerNum = RoundManager.Round.PlayerList.Count;

        if (playerNum == 0)
            Debug.LogError("0");

        Debug.Log($"playerMum is {playerNum}");

        for (int i = 0; i < playerNum; i++)
        {
            Instantiate(prefab, transform);
        }
    }

    // --> 권새롬 추가. 플레이어가 다 로드가 되었을 때 UI를 지정
    IEnumerator CoInitSideUI()
    {
        int tmpPlayerCount = PhotonNetwork.PlayerList.Length;
        int playerNum = RoundManager.Round.PlayerList.Count;

        while (true)
        {
            playerNum = RoundManager.Round.PlayerList.Count;
            if (playerNum == tmpPlayerCount)
                break;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        for (int i = 0; i < playerNum; i++)
        {
            Debug.LogError(i);
            Instantiate(prefab, transform);
        }
    }
}
