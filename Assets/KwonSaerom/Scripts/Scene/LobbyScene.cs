using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    [SerializeField] LobbyManager lobbyManager;
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

}
