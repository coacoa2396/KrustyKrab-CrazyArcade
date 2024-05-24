using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규 
/// 게임씬에서 사이드플레이어 인포 UI
/// </summary>
public class SidePlayerInfo : MonoBehaviour
{
    [Header("Icon")]
    [SerializeField] Image characterIcon;

    [Header("Level")]
    [SerializeField] TMP_Text level;

    [Header("NickName")]
    [SerializeField] TMP_Text nickName;

    [Header("DieJudge")]
    [SerializeField] TMP_Text dieJudge;

    [Header("IconList")]
    [SerializeField] List<Sprite> characterRender;

    List<PlayerRoundData> list;

    private void Start()
    {
        list = RoundManager.Round.PlayerList;

        foreach (PlayerRoundData p in list)
        {
            // 캐릭터 아이콘 설정            
            switch (p.playerEntity.Character)
            {
                case Define.Characters.Bazzi:
                    characterIcon.sprite = characterRender[0];
                    break;
                case Define.Characters.Cappi:
                    characterIcon.sprite = characterRender[1];
                    break;
                case Define.Characters.Dao:
                    characterIcon.sprite = characterRender[2];
                    break;
                case Define.Characters.Marid:
                    characterIcon.sprite = characterRender[3];
                    break;
            }

            // 레벨 설정
            level.text = $"{p.playerEntity.User.level}";

            // 닉네임 설정
            nickName.text = $"{p.playerEntity.User.nickName}";
        }
    }

    private void LateUpdate()
    {
        foreach (PlayerRoundData p in list)
        {
            // 사망 설정
            if (p.outcome == RoundManager.Outcome.lose)
            {
                dieJudge.gameObject.SetActive(true);
            }
        }
    }
}
