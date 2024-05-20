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

    string name;

    private void Start()
    {
        PlayerMediator[] players = FindObjectsOfType<PlayerMediator>();
        foreach (PlayerMediator player in players)
        {
            if (!photonView.IsMine)
                continue;

            this.player = player;
            break;
        }
    }

    private void LateUpdate()
    {

        if (player.CurActiveItem.Name == null)
        {
            name = null;
        }

        switch (name)
        {
            case "Needle":
                itemImage.sprite = sprites[0];
                itemName.text = "바늘";
                itemUseNumber.text = $"X {player.CurActiveItem.UseNumber}";
                break;
            case "Dart":
                itemImage.sprite = sprites[1];
                itemName.text = "다트";
                itemUseNumber.text = $"X {player.CurActiveItem.UseNumber}";
                break;
            case "Shield":
                itemImage.sprite = sprites[2];
                itemName.text = "방패";
                itemUseNumber.text = $"X {player.CurActiveItem.UseNumber}";
                break;
            case null:
                itemImage.sprite = null;
                itemName.text = "";
                itemUseNumber.text = "";
                break;
        }
    }
}
