using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class UserDataManager
{
    public static void CreateUserData(UserEntity user)
    {
        string json = JsonUtility.ToJson(user);
        string key = ToKey(user);

        FirebaseManager.DB
            .GetReference("User")
            .SetPriorityAsync(key)
            .ContinueWithOnMainThread(task =>
            {
                Debug.Log("완료");
            });
            

        FirebaseManager.DB
            .GetReference("User")
            .Child(key)
            .SetRawJsonValueAsync(json)
            .ContinueWithOnMainThread(task =>
            {
                Debug.Log(json);
            });
    }

    //로그인시 나의 데이터를 들고와서 저장함.
    public static void LocalLoginGetUserData(string id)
    {
        string key = ToKey(id);
        FirebaseManager.DB
            .GetReference("User")
            .Child(key)
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
                Manager.Game.Player = new PlayerEntity(user);
            });
    }

    public static void LocalUserSetConnect(int curConnect)
    {
        string key = ToKey(Manager.Game.Player.Key);
        FirebaseManager.DB
            .GetReference("User")
            .Child(key)
            .Child("isConnect")
            .SetValueAsync(curConnect)
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
                Debug.Log("LocalUserSetConnect : DB 처리 완료");
            });
    }


    // 플레이어의 경험치를 업데이트하는 함수
    //UserDataManager.SetPlayerExp(player,100)
    public static void SetPlayerExp(PlayerEntity player,float exp)
    {
        string key = ToKey(player.Key);
        float plusExp = player.User.exp + exp;
        int updateLevel = player.User.level + (int)plusExp / (int)player.User.maxExp;
        float updateExp = plusExp % player.User.maxExp;
        FirebaseManager.DB
            .GetReference("User")
            .Child(key)
            .Child("exp")
            .SetValueAsync(updateExp)
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
                Debug.Log("SetPlayerExp : DB 처리 완료");
            });

        FirebaseManager.DB
            .GetReference("User")
            .Child(key)
            .Child("level")
            .SetValueAsync(updateLevel)
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
                Debug.Log("SetPlayerLevelExp : DB 처리 완료");
            });

        float updateMaxExp = Define.MAX_EXP[updateLevel-1];
        FirebaseManager.DB
            .GetReference("User")
            .Child(key)
            .Child("maxExp")
            .SetValueAsync(updateMaxExp)
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
                Debug.Log("SetPlayerMaxExp : DB 처리 완료");
            });
        //float updateMaxExp = Define.MAX_EXP[updateLevel - 1];
        //FirebaseManager.DB
        //    .GetReference("User")
        //    .Child(key)
        //    .Child("maxExp")
        //    .SetValueAsync(updateLevel)
        //    .ContinueWithOnMainThread(task =>
        //    {
        //        if (task.IsCanceled)
        //        {
        //            Debug.Log("GetUserData : IsCanceled");
        //            return;
        //        }
        //        if (task.IsFaulted)
        //        {
        //            Debug.Log("GetUserData : IsFaulted");
        //            return;
        //        }
        //        Debug.Log("SetPlayerExp : DB 처리 완료");
        //    });
    }

    public static string ToKey(string userId)
    {
        return userId.Replace('@', 'a').Replace('.', 'b');
    }

    public static string ToKey(UserEntity user)
    {
        return user.key.Replace('@', 'a').Replace('.', 'b');
    }
}
