using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] Bomb waterBomb;
    [SerializeField] int size;
    [SerializeField] int capacity;
    private void Awake()
    {
        Manager.Pool.CreatePool(waterBomb, size, capacity);
    }
}
