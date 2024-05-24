using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    PlayerMediator playerMediator;

    
    [SerializeField] List<GameObject> inven;

    UnityAction<List<GameObject>> OnRelease;

    public List<GameObject> Inven
    {
        get
        {
            return inven;
        }
    }

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();

        if(inven != null) { inven = null; }
        inven = new List<GameObject>();

        OnRelease += ItemSpawner.ItemSpawn.ReleaseItem;
        if(OnRelease != null) { Debug.Log("사망 시 방출 이벤트 함수 등록됨"); }
    }

    private void OnDisable()
    {
        OnRelease?.Invoke(inven);
    }



}
