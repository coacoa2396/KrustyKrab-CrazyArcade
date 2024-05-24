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

    PlayerRoundData player;

    public Image CharacterIcon { get { return characterIcon; } set { characterIcon = value; } }
    public TMP_Text Level { get { return level; } set { level = value; } }
    public TMP_Text NickName { get { return nickName; } set { nickName = value; } }
    public List<Sprite> CharacterRender { get { return characterRender; } }

    private void LateUpdate()
    {
        // 사망 설정
        if (player.outcome == RoundManager.Outcome.lose)
        {
            dieJudge.gameObject.SetActive(true);
        }
    }

    public void SetPlayer(PlayerRoundData player)
    {
        this.player = player;
    }
}
