using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Scriptable Object : 스크럽터블 오브젝트로 캐릭터별 스텟 저장

[CreateAssetMenu(fileName ="ScriptableObject",menuName ="NewData/NewCharacter")]
public class CharacterStats : ScriptableObject
{

    [Header("캐릭터의 이동속도")]
    float speed;
    [Header("캐릭터의 물풍선 파워")]
    float powerValue;
    [Header("캐릭터의 초기 물풍선 개수")]
    float bombValue;


    public float Speed { get { return speed; } }
    public float Power{ get { return powerValue; } }
    public float Bomb { get { return bombValue; } }




}

