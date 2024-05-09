using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_TitleScene : InGameUI
{
    [SerializeField] UI_SignUp signUpPopup;
    enum GameObjects
    {
        LoginButton,
        QuitButton,
        SignUpButton,
        PasswordInputField,
        IdInputField
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.LoginButton.ToString()).onClick.AddListener(Login);
        GetUI<Button>(GameObjects.QuitButton.ToString()).onClick.AddListener(Quit);
        GetUI<Button>(GameObjects.SignUpButton.ToString()).onClick.AddListener(SignUp);
    }

    public void SignUp()
    {
        Manager.UI.ShowPopUpUI(signUpPopup);
    }

    public void Login()
    {
        SetInteractable(false);
        string id = GetUI<TMP_InputField>(GameObjects.IdInputField.ToString()).text;
        string password = GetUI<TMP_InputField>(GameObjects.PasswordInputField.ToString()).text;

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
                Debug.Log("dd");
                return;
            }

            Debug.Log("Login Success");
            SetInteractable(true);
            //씬 전환(로비씬으로)
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
        Debug.Log(interactable);
        GetUI<Button>(GameObjects.QuitButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.LoginButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.SignUpButton.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.PasswordInputField.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.IdInputField.ToString()).interactable = interactable;
        Debug.Log("complete");

    }

}
