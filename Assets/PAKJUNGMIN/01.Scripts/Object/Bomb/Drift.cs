using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class : 물줄기
/// </summary>
public class Drift : PooledObject
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 물줄기 범위 안에 있다면, 플레이어 상태를 감옥 상태로 변경
        if (collision.gameObject.GetComponent<PlayerStateMachine>())
        {
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //플레이어가 물줄기 범위 안에 있다면, 플레이어 상태를 감옥 상태로 변경
        if (collision.gameObject.GetComponent<PlayerStateMachine>())
        {
            
        }
    }
}
