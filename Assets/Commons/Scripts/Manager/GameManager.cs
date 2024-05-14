using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private PlayerEntity player;
    public PlayerEntity Player { get { return player; } set { player = value; } }
    public void Test()
    {
        Debug.Log(GetInstanceID());
    }
}
