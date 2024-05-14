using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class : 물줄기
/// </summary>
public class Stream : PooledObject
{

    public float driftTime = 1f;
    Coroutine courseCoroutine;

    IEnumerator CourseTime()
    {
        while (true)
        {
            driftTime -= Time.deltaTime;
            yield return null;
            if (driftTime <= 0)
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
        driftTime = 1f;
    }

}
