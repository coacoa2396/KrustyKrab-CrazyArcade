using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Room : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();
        if (Time.timeScale == 0)
            Time.timeScale = 1;

    }
}
