using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private UserEntity player;
    public UserEntity Player { get { return player; } set { player = value; } }
    public void Test()
    {
        Debug.Log(GetInstanceID());
    }
}
