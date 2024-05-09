using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleScene : InGameUI
{
    enum GameObjects
    {
        LoginButton,
        QuitButton,
        PasswordInputField,
        IdInputField
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.LoginButton.ToString()).onClick.AddListener(Login);
        GetUI<Button>(GameObjects.QuitButton.ToString()).onClick.AddListener(Quit);
    }

    public void Login()
    {
        SetInteractable(false);
        string id = GetUI<InputField>(GameObjects.IdInputField.ToString()).text;
        string password = GetUI<InputField>(GameObjects.PasswordInputField.ToString()).text;

        FirebaseManager.Auth.SignInWithEmailAndPasswordAsync(id, password).ContinueWith(task =>
        {
            if(task.IsCanceled)
            {
                Debug.Log("취소됨");
                SetInteractable(true);
                return;
            }
            if(task.IsFaulted)
            {
                Debug.Log("Faulted");
                SetInteractable(true);
                return;
            }

            Debug.Log("Login Success");
            SetInteractable(true);
        });
    }

    public void Quit()
    {
        SetInteractable(false);
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); // 어플리케이션 종료
        #endif
    }

    private void SetInteractable(bool interactable)
    {
        GetUI<Button>(GameObjects.LoginButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.QuitButton.ToString()).interactable = interactable;
        GetUI<InputField>(GameObjects.PasswordInputField.ToString()).interactable = interactable;
        GetUI<InputField>(GameObjects.IdInputField.ToString()).interactable = interactable;
    }

}
