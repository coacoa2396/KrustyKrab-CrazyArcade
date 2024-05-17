using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    [SerializeField] float gameTime;

    public float GameTime { get { return gameTime; } }

    private void Start()
    {
        gameTime = 180f;
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
    }
}
