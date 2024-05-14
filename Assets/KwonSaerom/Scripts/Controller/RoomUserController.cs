using Firebase.Database;
using Firebase.Extensions;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Define;

public class RoomUserController : MonoBehaviourPunCallbacks
{
    [SerializeField] List<Sprite> sprites;

    private UI_UserToken[] userTokens;
    private List<PlayerEntity> players;


    private void Awake()
    {
        players = new List<PlayerEntity>();
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
        AddPlayer(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
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
                userTokens[i].SetPlayer(players[i].User.nickName, sprites[(int)players[i].Character]);
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
                    players.Add(new PlayerEntity(user));
                    userTokens[players.Count - 1].SetPlayer(user.nickName, sprites[(int)Define.Characters.Bazzi]);
                });
    }

    private void RemovePlayer(Player player)
    {
        for(int i=0;i<players.Count;i++)
        {
            if (player.NickName.Equals(players[i].User.key))
                players.RemoveAt(i);
        }
        UpdatePlayer();
    }

    public void CharacterChange(Characters character)
    {
        string key = Manager.Game.Player.User.key;
        photonView.RPC("UpdateCharacterChange", RpcTarget.All, key, character);
    }


    [PunRPC]
    public void UpdateCharacterChange(string key,Characters character)
    {
        foreach(PlayerEntity player in players)
        {
            if(player.Key.Equals(key))
            {
                player.Character = character;
            }
        }
        UpdatePlayer();
    }
}
