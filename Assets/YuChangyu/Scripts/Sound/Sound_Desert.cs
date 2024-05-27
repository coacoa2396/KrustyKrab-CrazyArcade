using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Desert : MonoBehaviour
{
    private void Start()
    {
        Manager.Sound.StopBGM();
        Manager.Sound.PlayBGM("Desert");
    }

    private void OnDestroy()
    {
        Manager.Sound.StopBGM();
    }
}
