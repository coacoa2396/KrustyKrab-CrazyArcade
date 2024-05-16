using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_UserToken : BaseUI
{
    private PlayerEntity player;
    private bool onVisit = false;
    private bool onPlayer = false;

    public PlayerEntity Player { get { return player; } }

    enum GameObjects
    {
        BackgroundOK,
        UserNickname,
        PlayerImg,
        ReadyInfo
    }


    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// 캐릭터 들어올 수 있는 칸이면 활성화/ 아니면 비활성화
    /// </summary>
    public void SetVisit(bool onVisit)
    {
        this.onVisit = onVisit;
        GetUI(GameObjects.BackgroundOK.ToString()).SetActive(onVisit);
        OnPlayer(false);
    }



    public void SetPlayer(PlayerEntity entity,Sprite character)
    {
        if (!onVisit)
        {
            Debug.Log("onVisit is false");
            return;
        }
        player = entity;
        OnPlayer(true);
        GetUI<TMP_Text>(GameObjects.UserNickname.ToString()).text = entity.User.nickName;
        GetUI<Image>(GameObjects.PlayerImg.ToString()).sprite = character;
        GetUI(GameObjects.ReadyInfo.ToString()).SetActive(player.IsReady);
    }

    public void OnPlayer(bool onPlayer)
    {
        this.onPlayer = onPlayer;
        GetUI(GameObjects.UserNickname.ToString()).SetActive(onPlayer);
        GetUI(GameObjects.PlayerImg.ToString()).SetActive(onPlayer);
        GetUI(GameObjects.ReadyInfo.ToString()).SetActive(onPlayer);
    }


}
