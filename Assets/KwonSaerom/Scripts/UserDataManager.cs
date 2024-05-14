using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class UserDataManager
{
    public static UserEntity User = null;


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
                User = JsonUtility.FromJson<UserEntity>(snapshot.GetRawJsonValue());
                //User = new UserEntity(snapshot);
                Debug.Log(User.ToString());
            });
    }

    private static string ToKey(string userId)
    {
        return userId.Replace('@', 'a').Replace('.', 'b');
    }

    private static string ToKey(UserEntity user)
    {
        return user.Key.Replace('@', 'a').Replace('.', 'b');
    }



}
