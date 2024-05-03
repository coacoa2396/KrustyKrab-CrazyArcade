using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pakjungmin 
{

    public class PlayerBehavior : MonoBehaviour
    {
        PlayerMediator playerMediator;


        private void Awake()
        {
            playerMediator = GetComponent<PlayerMediator>();
            
        }

        public void Move(Vector3 moveDir)
        {
            PlayerStats stat = playerMediator.playerStats;
            gameObject.transform.Translate(moveDir*stat.Speed*Time.deltaTime,Space.World);
        }

        public void Plant()
        {

        }
        public void Use()
        {

        }
    }
}

