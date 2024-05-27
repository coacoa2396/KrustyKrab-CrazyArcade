using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Village : MonoBehaviour
{
    private void Start()
    {
        Manager.Sound.StopBGM();
        Manager.Sound.PlayBGM("Village");
    }

    private void OnDestroy()
    {
        Manager.Sound.StopBGM();
    }
}
