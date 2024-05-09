using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCourseSpawner : MonoBehaviour
{
    [SerializeField] Drift waterCourse;
    [SerializeField] int size;
    [SerializeField] int capacity;
    private void Awake()
    {
        Manager.Pool.CreatePool(waterCourse, size, capacity);
    }
}
