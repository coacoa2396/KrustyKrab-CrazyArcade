using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        RaycastHit2D[] tilerays;
        RaycastHit2D[] bombrays;

        int wallmask = 1 << LayerMask.NameToLayer("Wall");
        int tilemask = 1 << LayerMask.NameToLayer("Tile");
        int bombmask = 1 << LayerMask.NameToLayer("WaterBomb");

        switch (playerMediator.forwardGuide.Forward)
        {
            case ForwardGuide.ForwardState.up:

                ray = Physics2D.Raycast(startPos, startTile.transform.up,15f,wallmask); //Wall만 체크하는 레이캐스트 발사.
                if (ray.collider != null && ray.collider.gameObject.GetComponent<BaseWall>()) //Wall이 걸리면.
                {
                    ResetBombData(bomb, ray, 0,-1);

                }
                else if (ray.collider == null) //아무것도 없었을 경우.
                {
                    bombrays = Physics2D.RaycastAll(startPos, startTile.transform.up, 15f, bombmask); //폭탄 체크

                    if (bombrays.Length >= 2)
                    {
                        TileNode tilenode_;
                        tilenode_ = bombrays[bombrays.Length-1].collider.gameObject.GetComponent<Bomb>().tileNode;
                        bomb.StopExplodeCoroutine();
                        bomb.PosX = tilenode_.posX;
                        bomb.PosY = tilenode_.posY;
                        bomb.transform.position = TileManager.Tile.tileDic[$"{tilenode_.posX},{tilenode_.posY}"].transform.position;
                        bomb.StartExplodeCoroutine();
                    }
                    else
                    {
                        tilerays = Physics2D.RaycastAll(startPos, startTile.transform.up, 15f, tilemask);

                        if (tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>()) //마지막으로 타일 체크
                        {
                            Tile lastTile = tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>();
                            bomb.StopExplodeCoroutine();
                            bomb.PosX = lastTile.tileNode.posX;
                            bomb.PosY = lastTile.tileNode.posY;
                            bomb.transform.position = TileManager.Tile.tileDic[$"{lastTile.tileNode.posX},{lastTile.tileNode.posY}"].transform.position;
                            bomb.StartExplodeCoroutine();
                            
                        }
                    }
                   
                }
                break;
            case ForwardGuide.ForwardState.down:

                ray = Physics2D.Raycast(startPos, -startTile.transform.up, 15f, wallmask);
                if (ray && ray.collider.gameObject.GetComponent<BaseWall>())
                {
                    ResetBombData(bomb, ray, 0, +1);
                }
                else if (!ray)
                {
                    tilerays = Physics2D.RaycastAll(startPos,-startTile.transform.up, 15f, tilemask);
                    if (tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>())
                    {
                        Tile lastTile = tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>();
                        bomb.StopExplodeCoroutine();
                        bomb.PosX = lastTile.tileNode.posX;
                        bomb.PosY = lastTile.tileNode.posY;
                        bomb.transform.position = TileManager.Tile.tileDic[$"{lastTile.tileNode.posX},{lastTile.tileNode.posY}"].transform.position;
                        bomb.StartExplodeCoroutine();
                    }
                }
                break;

            case ForwardGuide.ForwardState.left:
                ray = Physics2D.Raycast(startPos, startTile.transform.right, 15f, wallmask);
                if (ray && ray.collider.gameObject.GetComponent<BaseWall>()) 
                {
                    ResetBombData(bomb, ray, -1, 0);
                }
                else if (!ray)
                {
                    tilerays = Physics2D.RaycastAll(startPos, startTile.transform.right, 15f, tilemask);
                    if (tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>())
                    {
                        Tile lastTile = tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>();
                        bomb.StopExplodeCoroutine();
                        bomb.PosX = lastTile.tileNode.posX;
                        bomb.PosY = lastTile.tileNode.posY;
                        bomb.transform.position = TileManager.Tile.tileDic[$"{lastTile.tileNode.posX},{lastTile.tileNode.posY}"].transform.position;
                        bomb.StartExplodeCoroutine();
                    }
                }
                break;

            case ForwardGuide.ForwardState.right:
                ray = Physics2D.Raycast(startPos, -startTile.transform.right, 15f, wallmask);
                if (ray && ray.collider.gameObject.GetComponent<BaseWall>())
                {
                   ResetBombData(bomb, ray, +1, 0);
                }

                else if (!ray)
                {
                    tilerays = Physics2D.RaycastAll(startPos,-startTile.transform.right, 15f, tilemask);
                    if (tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>())
                    {
                        Tile lastTile = tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>();
                        bomb.StopExplodeCoroutine();
                        bomb.PosX = lastTile.tileNode.posX;
                        bomb.PosY = lastTile.tileNode.posY;
                        bomb.transform.position = TileManager.Tile.tileDic[$"{lastTile.tileNode.posX},{lastTile.tileNode.posY}"].transform.position;
                        bomb.StartExplodeCoroutine();
                    }
                }
                break;
        }
        
    }

    void ResetBombData(Bomb bomb,RaycastHit2D ray,int x,int y)
    {
        TileNode tilenode_;
        if (ray.collider.GetComponent<BaseWall>())
        {
            tilenode_ = ray.collider.gameObject.GetComponent<BaseWall>().tileNode;
            bomb.StopExplodeCoroutine();
            bomb.PosX = tilenode_.posX + x;
            bomb.PosY = tilenode_.posY + y;
            bomb.transform.position = TileManager.Tile.tileDic[$"{tilenode_.posX + x},{tilenode_.posY + y}"].transform.position;
            bomb.StartExplodeCoroutine();
        }


    }
    

}
