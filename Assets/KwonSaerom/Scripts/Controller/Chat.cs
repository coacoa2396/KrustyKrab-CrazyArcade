using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviourPun
{
    [SerializeField] TMP_Text textPrefab;
    [SerializeField] GameObject content;
    [SerializeField] ScrollRect chatView;
    [SerializeField] TMP_InputField chatInput;
    [SerializeField] Button sendButton;

    private PlayerEntity nowPlayer;

    
    private void Awake()
    {
        nowPlayer = Manager.Game.Player;
        sendButton.onClick.AddListener(SendChat);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SendChat();
        }
    }

    public void SendChat()
    {
        string message = chatInput.text;
        if (message == "")
            return;

        photonView.RPC("UpdateChat", RpcTarget.All, message, nowPlayer.User.nickName);
        chatInput.text = "";
        chatInput.ActivateInputField();
    }

    [PunRPC]
    public void UpdateChat(string message,string nickName)
    {
        TMP_Text textMessage = Instantiate(textPrefab, content.transform);
        textMessage.text = $"{nickName} : {message}";
        chatView.verticalScrollbar.value = 0;
    }
}
