using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_UserToken : BaseUI
{
    private bool onVisit = false;
    private bool onPlayer = false;

    enum GameObjects
    {
        BackgroundOK,
        UserNickname,
        PlayerImg
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



    public void SetPlayer(string nickName,Sprite character)
    {
        if (!onVisit)
        {
            Debug.Log("onVisit is false");
            return;
        }
        if (onPlayer == true)
            return;
        OnPlayer(true);
        GetUI<TMP_Text>(GameObjects.UserNickname.ToString()).text = nickName;
        GetUI<Image>(GameObjects.PlayerImg.ToString()).sprite = character;
    }

    public void OnPlayer(bool onPlayer)
    {
        this.onPlayer = onPlayer;
        GetUI(GameObjects.UserNickname.ToString()).SetActive(onPlayer);
        GetUI(GameObjects.PlayerImg.ToString()).SetActive(onPlayer);
    }


}
