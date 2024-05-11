using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Warning : PopUpUI
{
    enum GameObjects
    {
        LogText,
        CloseButton
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.CloseButton.ToString()).onClick.AddListener(Close);
    }

    public void SetLog(string log)
    {
        GetUI<TMP_Text>(GameObjects.LogText.ToString()).text = log;
    }
}
