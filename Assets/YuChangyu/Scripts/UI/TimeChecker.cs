using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    [SerializeField] GameFlow gameFlow;

    [SerializeField] float gameTime;

    public float GameTime { get { return gameTime; } }

    private void Start()
    {
        gameTime = 180f;
    }

    private void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
        }
        else
        {
            gameTime = 0;
            gameFlow.Judge();
        }
    }
}
