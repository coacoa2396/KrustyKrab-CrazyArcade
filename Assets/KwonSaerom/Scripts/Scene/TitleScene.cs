using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return new WaitForSeconds(3f);
        PhotonNetwork.ConnectUsingSettings();
    }
}
