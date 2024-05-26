using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TitleLoad());
    }

    IEnumerator TitleLoad()
    {
        yield return new WaitForSeconds(3f);

        Manager.Scene.LoadScene("TitleScene");
    }
}
