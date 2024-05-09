using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class UI_SignUp : PopUpUI
{
    enum GameObjects
    {
        SignUpButton,
        CloseButton,
        IDInput,
        PWInput,
        PWConfirmInput,
        NickNameInput
    }

    protected override void Awake()
    {
        base.Awake();
        GetUI<Button>(GameObjects.SignUpButton.ToString()).onClick.AddListener(SignUp);
        GetUI<Button>(GameObjects.CloseButton.ToString()).onClick.AddListener(Manager.UI.ClearPopUpUI);
    }

    public void SignUp()
    {
        SetInteractable(false);
        string id = GetUI<TMP_InputField>(GameObjects.IDInput.ToString()).text;
        string pw = GetUI<TMP_InputField>(GameObjects.PWInput.ToString()).text;
        string confirm = GetUI<TMP_InputField>(GameObjects.PWConfirmInput.ToString()).text;
        string nickName = GetUI<TMP_InputField>(GameObjects.NickNameInput.ToString()).text;

        if(pw != confirm)
        {
            Debug.Log("비밀번호 확인 에러");
            SetInteractable(true);
            return;
        }

        FirebaseManager.Auth.CreateUserWithEmailAndPasswordAsync(id, pw).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Canceled");
                SetInteractable(true);
                return;
            }
            if (task.IsFaulted)
            {
                Debug.Log("Faulted");
                SetInteractable(true);
                return;
            }

            Debug.Log("회원가입 완료");
            Manager.UI.ClearPopUpUI();
            SetInteractable(true);
        });

    }

    private void SetInteractable(bool interactable)
    {
        GetUI<Button>(GameObjects.SignUpButton.ToString()).interactable = interactable;
        GetUI<Button>(GameObjects.CloseButton.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.IDInput.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.PWInput.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.PWConfirmInput.ToString()).interactable = interactable;
        GetUI<TMP_InputField>(GameObjects.NickNameInput.ToString()).interactable = interactable;
    }
}
