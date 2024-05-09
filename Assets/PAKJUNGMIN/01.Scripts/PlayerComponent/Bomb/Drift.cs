using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class : 물줄기
/// </summary>
public class Drift : PooledObject
{
    Coroutine courseCoroutine;

    //IEnumerator CourseTime()
    //{
    //    coursetime -= Time.deltaTime;
    //    yield return null;
    //    if(coursetime <= 0)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}

    ////private void OnEnable()
    ////{
    ////    courseCoroutine = StartCoroutine(CourseTime());
    ////}
    ////private void OnDisable()
    ////{
    ////    //coursetime = 0.3f;
    ////}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어가 물줄기 범위 안에 있다면, 플레이어 상태를 감옥 상태로 변경
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //플레이어가 물줄기 범위 안에 있다면, 플레이어 상태를 감옥 상태로 변경
    }
}
