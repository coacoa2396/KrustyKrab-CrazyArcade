using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_WarningRoom : MonoBehaviour
{
    [SerializeField] TMP_Text log;
    [SerializeField] Button closeBtn;
    enum GameObjects
    {
        LogText,
        CloseButton
    }

    private void Awake()
    {
        closeBtn.onClick.AddListener(Close);
    }

    public void SetLog(string log)
    {
        this.log.text = log;
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
