using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규
/// 플레이어리스트에서 가져온 플레이어의 결과창 상세 목록
/// </summary>
public class PlayerInfo : MonoBehaviour
{
    [Header("Result")]
    [SerializeField] Image win;
    [SerializeField] Image lose;
    [SerializeField] Image draw;

    [Header("NickName")]
    [SerializeField] TMP_Text nickName;

    [Header("Level")]
    [SerializeField] TMP_Text level;

    [Header("EXP")]
    [SerializeField] TMP_Text EXP;

    [Header("LevelUp")]
    [SerializeField] TMP_Text levelUp;

    public void SetPlayerInfo(PlayerRoundData p)
    {
        // result Judge
        switch (p.outcome)
        {
            case RoundManager.Outcome.Win:
                win.gameObject.SetActive(true);
                break;
            case RoundManager.Outcome.lose:
                lose.gameObject.SetActive(true);
                break;
            case RoundManager.Outcome.draw:
                draw.gameObject.SetActive(true);
                break;
        }

        // nickName Judge
        nickName.text = p.playerEntity.User.nickName;


        // EXP Judge
        if (p.playerEntity.User.exp + 10 < p.playerEntity.User.maxExp)      // 게임 경험치를 더해도 레벨업을 못할 때
        {
            // level Judge
            level.text = (p.playerEntity.User.level).ToString();
            EXP.text = $"{p.playerEntity.User.exp + 10} / {p.playerEntity.User.maxExp}";
            // levelUp Judge
            levelUp.gameObject.SetActive(false);
        }
        else                                                                // 맥스 경험치와 같거나 넘어서서 레벨업을 할 때
        {
            level.text = (p.playerEntity.User.level + 1).ToString();
            EXP.text = $"{(p.playerEntity.User.exp + 10) - p.playerEntity.User.maxExp} / {Define.MAX_EXP[p.playerEntity.User.level]}";
            levelUp.gameObject.SetActive(true);
        }
    }
}
