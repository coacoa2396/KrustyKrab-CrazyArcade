using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
        LayerMask layer = LayerMask.GetMask("Wall");
        float randomPosX, randomPosY;
        while (true)
        {
            randomPosX = Random.Range(-9f, 8.5f);
            randomPosY = Random.Range(-9.5f, 4f);

            Vector3 spawnPos = new Vector3(randomPosX, randomPosY, 0);
            Vector3 startPos = Camera.main.transform.position;
            Vector3 direction = (spawnPos - startPos).normalized;
            float maxDistance = Vector3.Distance(startPos, spawnPos);

            Debug.DrawRay(startPos, direction * maxDistance, Color.red, 3);
            RaycastHit2D hit = Physics2D.Raycast(startPos, spawnPos - startPos);
            if (hit.collider != null)
            {
                if (layer.Contain(hit.collider.gameObject.layer) == false) //벽이 아니면
                {
                    break;
                }
            }
            yield return new WaitForSecondsRealtime(0.5f);
        }
        PhotonNetwork.Instantiate("Prefabs/Character/Player", new Vector3(randomPosX, randomPosY, 0), Quaternion.identity);
    }
}
