using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Title : MonoBehaviour
{
    private void Start()
    {
        Manager.Sound.PlayBGM("Title");
    }

    private void OnDestroy()
    {
        Manager.Sound.StopBGM();
    }
}
