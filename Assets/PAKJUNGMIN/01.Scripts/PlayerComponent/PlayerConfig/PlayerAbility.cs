using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Class : 플레이어에게 부여된 능력 혹은 상태이상
/// </summary>
public class PlayerAbility : MonoBehaviour
{
    PlayerMediator playerMediator;
    //능력 여부 
    public bool onRide;
    public bool canThrow;
    public bool canKick;
    //던지기와 킥이 둘다 가능할때 던지기만 하도록 조정해야한다.

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }


    /// <summary>
    /// Method : 플레이어가 탈 것을 탑승
    /// </summary>
    public void Ride()
    {

    }
    /// <summary>
    /// Method : 플레이어가 물풍선을 던지는 능력. --> 물풍선이 발 밑에 있을 경우만 작동
    /// </summary>
    public void Throw()
    {
        if (!canThrow) { return; }
        if (!playerMediator.playerInventory.Inven.Exists((gameObject_ => gameObject_.GetComponent<Glove>())))
        {
           // Debug.Log("글러브 없음");
            return; 
        }
        if(canThrow)
        {
          // Bomb bomb = GetComponentInChildren<KickAbilityChecker>().targetBomb;
           // bomb.gameObject.
        }
        
    }
    /// <summary>
    /// Method : 플레이어가 물풍선을 차는 능력. --> 물풍선이 플레이어의 앞에 있을 경우에만 작동
    /// </summary>
    public void Kick()
    {
        if (!canKick) { return; }

        if (!playerMediator.playerInventory.Inven.Exists((gameObject_ => gameObject_.GetComponent<Shoes>())))
        {
            //Debug.Log("신발 없음");
            return;
        }

        Bomb bomb = GetComponentInChildren<KickAbilityChecker>().targetBomb;

        Tile startTile = TileManager.Tile.tileDic[$"{bomb.GetComponent<Bomb>().tileNode.posX},{bomb.GetComponent<Bomb>().tileNode.posY}"];
             
        Vector2 startPos = startTile.transform.position; //폭탄의 위치 노드

        RaycastHit2D ray;

        int wallmask = 1 << LayerMask.NameToLayer("Wall");

        switch (playerMediator.forwardGuide.Forward)
        {
            case ForwardGuide.ForwardState.up:
                Debug.DrawRay(startPos,startTile.transform.up*15, Color.red,3f);

                ray = Physics2D.Raycast(startPos, startTile.transform.up,15f,wallmask);
                Debug.Log($"레이케스트에 부딪힌 물체 이름 : {ray.collider.gameObject.name}");
                if (ray.collider.gameObject.GetComponent<BaseWall>())
                {
                    TileNode tilenode_ = ray.collider.gameObject.GetComponent<BaseWall>().tileNode;
                    Vector2 moveDir = TileManager.Tile.tileDic[$"{tilenode_.posX},{tilenode_.posY}"].transform.position;
                    bomb.transform.Translate(TileManager.Tile.tileDic[$"{tilenode_.posX},{tilenode_.posY-1}"].transform.position);
                    Debug.Log("sfdasdf");
                }
                break;
            case ForwardGuide.ForwardState.down:

                ray = Physics2D.Raycast(startPos, -startTile.transform.up, 15f, wallmask);
                Debug.Log($"레이케스트에 부딪힌 물체 이름 : {ray.collider.gameObject.name}");
                Debug.DrawRay(startPos,-startTile.transform.up *15, Color.red, 3f);
                break;

            case ForwardGuide.ForwardState.left:
                ray = Physics2D.Raycast(startPos, startTile.transform.right, 15f, wallmask);
                Debug.Log($"레이케스트에 부딪힌 물체 이름 : {ray.collider.gameObject.name}");
                Debug.DrawRay(startPos,startTile.transform.right *15, Color.red, 3f);
                break;

            case ForwardGuide.ForwardState.right:
                ray = Physics2D.Raycast(startPos, -startTile.transform.right, 15f, wallmask);
                Debug.Log($"레이케스트에 부딪힌 물체 이름 : {ray.collider.gameObject.name}");
                Debug.DrawRay(startPos,-startTile.transform.right *15, Color.red, 3f);
                break;
        }
        
    }
    

}
