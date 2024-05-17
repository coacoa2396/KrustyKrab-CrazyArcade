using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class : 물줄기
/// </summary>
public class Stream : PooledObject
{
    public float stream_time = 0.5f;
    Coroutine courseCoroutine;

    IEnumerator CourseTime()
    {
        while (true)
        {
            stream_time -= Time.deltaTime;
            yield return null;
            if (stream_time <= 0)
            {
                gameObject.SetActive(false);
                break;
            }
        }
    }

    private void OnEnable()
    {
        courseCoroutine = StartCoroutine(CourseTime());
    }
    private void OnDisable()
    {
        stream_time = 0.5f;
    }

}
