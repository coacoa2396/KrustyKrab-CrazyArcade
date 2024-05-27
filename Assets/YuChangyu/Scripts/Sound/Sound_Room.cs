using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 제작 : 찬규 
/// 룸에 들어갔을 때 사운드
/// </summary>
public class Sound_Room : MonoBehaviour
{
    private void Start()
    {
        Manager.Sound.StopBGM();
        RoomSound();
    }

    private void OnDestroy()
    {
        Manager.Sound.StopBGM();
    }

    public void RoomSound()
    {
        Manager.Sound.PlayBGM("Room");
    }
}
