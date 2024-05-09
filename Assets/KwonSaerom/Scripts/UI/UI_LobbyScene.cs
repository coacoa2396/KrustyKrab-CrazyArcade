using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_LobbyScene : InGameUI
{
    enum GameObjects
    {
        CreateRoomButton,
        QuitButton,
        QuickPlayButton
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.CreateRoomButton.ToString()).onClick.AddListener(CreateRoom);
        GetUI<Button>(GameObjects.QuitButton.ToString()).onClick.AddListener(Quit);
        GetUI<Button>(GameObjects.QuickPlayButton.ToString()).onClick.AddListener(QuickPlayer);
    }


    public void CreateRoom()
    {
        
    }
    
    public void QuickPlayer()
    {

    }

    public void Quit()
    {
        SetInteractable(false);
        Manager.Scene.LoadScene("TitleScene");
    }

    private void SetInteractable(bool interactable)
    {
        GetUI<Button>(GameObjects.QuitButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.CreateRoomButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.QuickPlayButton.ToString()).interactable = interactable;
    }

}
