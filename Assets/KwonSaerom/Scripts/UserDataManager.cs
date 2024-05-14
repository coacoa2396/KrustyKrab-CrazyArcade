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

    public static UserEntity GetUserData(string id)
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
                    return null;
                }
                if (task.IsFaulted)
                {
                    Debug.Log("GetUserData : IsFaulted");
                    return null;
                }
                DataSnapshot snapshot = task.Result;
                string json = snapshot.GetRawJsonValue();
                Debug.Log(json);
                return JsonUtility.FromJson<UserEntity>(json);
            });
        return null;
    }

    private static string ToKey(string userId)
    {
        return userId.Replace('@', 'a').Replace('.', 'b');
    }

    private static string ToKey(UserEntity user)
    {
        return user.key.Replace('@', 'a').Replace('.', 'b');
    }



}
