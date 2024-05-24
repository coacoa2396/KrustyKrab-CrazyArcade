using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 제작 : 찬규 
/// 결과UI에 승패무를 표시
/// </summary>
public class Result : MonoBehaviour
{
    [SerializeField] Image Win;
    [SerializeField] Image Lose;
    [SerializeField] Image Draw;

    PlayerRoundData Me;

    private void Start()
    {
        foreach (PlayerRoundData _me in RoundManager.Round.PlayerList)
        {
            if (_me.player.GetComponent<PhotonView>())
            {
                PhotonView view = _me.player.GetComponent<PhotonView>();

                if (view.IsMine)
                {
                    this.Me = _me;
                }
            }
        }

        if (Me == null)
        {
            Debug.Log("null"); return;
        }

        switch (Me.outcome)
        {
            case RoundManager.Outcome.Win:
                Win.gameObject.SetActive(true); 
                break;
            case RoundManager.Outcome.lose:
                Lose.gameObject.SetActive(true);
                break;
            case RoundManager.Outcome.draw:
                Draw.gameObject.SetActive(true);
                break;
        }
    }
}
