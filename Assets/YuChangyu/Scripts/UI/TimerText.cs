using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] TimeChecker timeChecker;

    int minute;
    float seconds;

    private void LateUpdate()
    {
        minute = (int)timeChecker.GameTime / 60;
        seconds = (int)timeChecker.GameTime % 60;

        text.text = $"{minute} : {seconds}";
    }
}
