using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene,IPunObservable
{
    Transform[] loadPosList;
    List<bool> isLoad;
    int index = -1;

    private void Start()
    {
        loadPosList = GetComponentsInChildren<Transform>();
        isLoad = new List<bool>();
        for (int i = 0; i < loadPosList.Length; i++)
            isLoad.Add(false);
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
        while(true)
        {
            int num = Random.Range(0, loadPosList.Length);
            if (isLoad[num] == false)
            {
                index = num;
                isLoad[index] = true;
                break;
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }

        Transform transform = loadPosList[index];
        PhotonNetwork.Instantiate("Prefabs/Character/Player", transform.position, Quaternion.identity);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            if (index != -1)
                stream.SendNext(index);
        }
        else
        {
            int receive = (int)stream.ReceiveNext();
            isLoad[receive] = true;
        }
    }
}
