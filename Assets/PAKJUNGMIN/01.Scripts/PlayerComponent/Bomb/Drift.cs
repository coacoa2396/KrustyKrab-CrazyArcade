using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class : 물줄기
/// </summary>
public class Drift : PooledObject
{

    float driftTime = 0.7f;
    Coroutine courseCoroutine;

    IEnumerator CourseTime()
    {
        driftTime -= Time.deltaTime;
        yield return null;
        if (driftTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        courseCoroutine = StartCoroutine(CourseTime());
    }
    private void OnDisable()
    {
        driftTime = 0.7f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 물줄기 범위 안에 있다면, 플레이어 상태를 감옥 상태로 변경
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //플레이어가 물줄기 범위 안에 있다면, 플레이어 상태를 감옥 상태로 변경
    }
}
