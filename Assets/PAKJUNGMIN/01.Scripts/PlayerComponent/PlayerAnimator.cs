using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pakjungmin;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{
    PlayerMediator playerMediator;

    [SerializeField] Image playertrapped;
    [SerializeField] Image playerdied;

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }


}
