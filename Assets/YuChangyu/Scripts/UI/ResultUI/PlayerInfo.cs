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

        // level Judge
        level.text = (p.playerEntity.User.level).ToString();
        EXP.text = $"{p.playerEntity.User.exp} / {p.playerEntity.User.maxExp}";
        // levelUp Judge
        levelUp.gameObject.SetActive(false);

    }
}
