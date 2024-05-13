using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UserToken : BaseUI
{
    private bool onVisit = false;
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
        GetUI(GameObjects.UserNickname.ToString()).SetActive(onVisit);
        GetUI(GameObjects.PlayerImg.ToString()).SetActive(onVisit);
    }

    public void SetPlayer()
    {
        if (!onVisit)
        {
            Debug.Log("onVisit is false");
            return;
        }
    }

}
