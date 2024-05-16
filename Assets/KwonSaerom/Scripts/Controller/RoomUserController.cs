using Firebase.Database;
using Firebase.Extensions;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static Define;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class RoomUserController : MonoBehaviourPunCallbacks
{
    [SerializeField] List<Sprite> sprites;

    private UI_UserToken[] userTokens;
    private List<PlayerEntity> players;
    public List<PlayerEntity> Players { get { return players; } }

    private void Awake()
    {
        players = new List<PlayerEntity>();
    }

    private void Start()
    {
        userTokens = GetComponentsInChildren<UI_UserToken>();
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for (int i=0;i<userTokens.Length;i++)
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
        AddPlayer(newPlayer,players.Count);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemovePlayer(otherPlayer);
    }

    private void InitRoom()
    {
        players.Clear();

        for (int i=0;i< PhotonNetwork.PlayerList.Length;i++)
        {
            AddPlayer(PhotonNetwork.PlayerList[i],i);
        }
    } 

    private void UpdatePlayer()
    {
        int maxPlayer = LobbyManager.NowRoom.MaxPlayer;
        for (int i = 0; i < maxPlayer; i++)
        {
            if (i < players.Count)
                userTokens[i].SetPlayer(players[i], sprites[(int)players[i].Character]);
            else
                userTokens[i].OnPlayer(false);
        }
    }

    private void AddPlayer(Player player,int index)
    {
        if (player.IsMasterClient)
            index = 0;
        else if (index == 0) //마스터 클라이언트가 아닌데 index가 0이면(반장자리)
            index = 1;

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
                    //플레이어 정보 불러오기
                    DataSnapshot snapshot = task.Result;
                    UserEntity user = JsonUtility.FromJson<UserEntity>(snapshot.GetRawJsonValue());

                    //캐릭터선택 정보 불러오기
                    Hashtable ht = player.CustomProperties;
                    PlayerEntity entity = new PlayerEntity(user, (Characters)(int)ht["Character"], (bool)ht["Ready"]);
                    players.Add(entity);

                    //플레이어 정보를 UI에 저장
                    userTokens[index].SetPlayer(entity, sprites[(int)entity.Character]);
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
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "Character", (int)character } });

        string key = Manager.Game.Player.User.key;
        photonView.RPC("UpdateCharacterChange", RpcTarget.All, key, character);
    }

    public void ReadyChange(bool isReady)
    {
        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { "Ready", true } });

        string key = Manager.Game.Player.User.key;
        photonView.RPC("UpdateReadyChange", RpcTarget.All, key, isReady);
    }

    [PunRPC] 
    public void UpdateCharacterChange(string key,Characters character)
    {
        foreach (PlayerEntity player in players)
        {
            if (player.Key.Equals(key))
            {
                player.Character = character;
            }
        }
        UpdatePlayer();
    }

    [PunRPC]
    public void UpdateReadyChange(string key, bool isReady)
    {
        foreach (PlayerEntity player in players)
        {
            if (player.Key.Equals(key))
            {
                player.IsReady = isReady;
            }
        }
        UpdatePlayer();
    }


}
