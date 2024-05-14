using Firebase.Database;
using Firebase.Extensions;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoomUserController : MonoBehaviourPunCallbacks
{
    [SerializeField] List<Sprite> sprites;

    private UI_UserToken[] userTokens;
    private List<UserEntity> players;


    private void Awake()
    {
        players = new List<UserEntity>();
    }

    private void Start()
    {
        userTokens = GetComponentsInChildren<UI_UserToken>();
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for(int i=0;i<userTokens.Length;i++)
        {
            if (i < maxPlayer)
                userTokens[i].SetVisit(true);
            else
                userTokens[i].SetVisit(false);
        }
        InitRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogError(newPlayer.NickName+" 들어옴");
        AddPlayer(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogError(otherPlayer.NickName+" 나감");
        RemovePlayer(otherPlayer);
    }

    private void InitRoom()
    {
        players.Clear();
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddPlayer(player);
        }
    }

    private void UpdatePlayer()
    {
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for (int i = 0; i < maxPlayer; i++)
        {
            if (i < players.Count)
                userTokens[i].SetPlayer(players[i].nickName, sprites[(int)Define.Characters.Marid]);
            else
                userTokens[i].OnPlayer(false);
        }
    }

    private void AddPlayer(Player player)
    {
        FirebaseManager.DB
                .GetReference("User")
                .Child(UserDataManager.ToKey(player.NickName))
                .GetValueAsync()
                .ContinueWithOnMainThread(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.Log("GetUserData : IsCanceled");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.Log("GetUserData : IsFaulted");
                        return;
                    }
                    DataSnapshot snapshot = task.Result;
                    UserEntity user = JsonUtility.FromJson<UserEntity>(snapshot.GetRawJsonValue());
                    players.Add(user);
                    userTokens[players.Count - 1].SetPlayer(user.nickName, sprites[(int)Define.Characters.Marid]);
                });
    }

    private void RemovePlayer(Player player)
    {
        for(int i=0;i<players.Count;i++)
        {
            if (player.NickName.Equals(players[i].key))
                players.RemoveAt(i);
        }
        UpdatePlayer();
    }
}
