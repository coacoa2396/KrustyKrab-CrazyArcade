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
        List<PlayerRoundData> list = RoundManager.Round.PlayerList;

        foreach (PlayerRoundData p in list)
        {
            SidePlayerInfo _info = Instantiate(prefab, transform);
            // 캐릭터 아이콘 설정            
            switch (p.playerEntity.Character)
            {
                case Define.Characters.Bazzi:
                    _info.CharacterIcon.sprite = _info.CharacterRender[0];
                    break;
                case Define.Characters.Cappi:
                    _info.CharacterIcon.sprite = _info.CharacterRender[1];
                    break;
                case Define.Characters.Dao:
                    _info.CharacterIcon.sprite = _info.CharacterRender[2];
                    break;
                case Define.Characters.Marid:
                    _info.CharacterIcon.sprite = _info.CharacterRender[3];
                    break;
            }

            // 레벨 설정
            _info.Level.text = $"{p.playerEntity.User.level}";

            // 닉네임 설정
            _info.NickName.text = $"{p.playerEntity.User.nickName}";

            _info.SetPlayer(p);
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
            InitSideUI();
        }
    }
}
