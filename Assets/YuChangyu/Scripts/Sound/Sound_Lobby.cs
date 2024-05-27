using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 로비씬의 사운드관련 함수들
/// </summary>
public class Sound_Lobby : MonoBehaviour
{
    private void Start()
    {
        Manager.Sound.StopBGM();
        LobbySound();
    }

    private void OnDestroy()
    {
        Manager.Sound.StopBGM();
    }

    public void LobbySound()
    {
        Manager.Sound.PlayBGM("Lobby");
    }
}
