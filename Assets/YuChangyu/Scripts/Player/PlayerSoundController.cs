using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public void TakeHitSound()
    {
        Manager.Sound.PlaySFX("TakeHit");
    }

    public void DieSound()
    {
        Manager.Sound.PlaySFX("Die");
    }
}
