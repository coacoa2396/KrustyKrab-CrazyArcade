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
        int playerNum = RoundManager.Round.PlayerList.Count;

        for (int i = 0; i < playerNum; i++)
        {
            Instantiate(prefab, transform);
        }
    }
}
