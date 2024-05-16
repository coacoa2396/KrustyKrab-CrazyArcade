using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamPooler : MonoBehaviour
{
    [SerializeField] Stream waterCourse;
    [SerializeField] int size;
    [SerializeField] int capacity;
    private void Awake()
    {
        Manager.Pool.CreatePool(waterCourse, size, capacity);
    }
}
