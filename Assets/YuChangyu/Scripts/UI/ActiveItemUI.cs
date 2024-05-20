using pakjungmin;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveItemUI : MonoBehaviourPun
{
    [SerializeField] PlayerMediator player;
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemUseNumber;

    [SerializeField] Sprite[] sprites;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        PlayerPhotonContoller[] _players = new PlayerPhotonContoller[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            _players[i] = players[i].GetComponent<PlayerPhotonContoller>();
        }

        foreach (PlayerPhotonContoller player in _players)
        {
            if (!player.PV.IsMine)
                continue;

            this.player = player.GetComponent<PlayerMediator>();
            break;
        }

        name = null;
    }

    private void LateUpdate()
    {
        if (player.CurActiveItem == null)
        {
            itemImage.sprite = null;
            itemImage.color = new Color(1, 1, 1, 0);
            itemName.text = "";
            itemUseNumber.text = "";
        }
        else
        {
            switch (player.CurActiveItem.Name)
            {
                case "Needle":
                    itemImage.sprite = sprites[0];
                    itemImage.color = new Color(1, 1, 1, 1);
                    itemName.text = "바늘";
                    itemUseNumber.text = $"X {player.CurActiveItem.UseNumber}";
                    break;
                case "Dart":
                    itemImage.sprite = sprites[1];
                    itemImage.color = new Color(1, 1, 1, 1);
                    itemName.text = "다트";
                    itemUseNumber.text = $"X {player.CurActiveItem.UseNumber}";
                    break;
                case "Shield":
                    itemImage.sprite = sprites[2];
                    itemImage.color = new Color(1, 1, 1, 1);
                    itemName.text = "방패";
                    itemUseNumber.text = $"X {player.CurActiveItem.UseNumber}";
                    break;
            }
        }
    }
}
