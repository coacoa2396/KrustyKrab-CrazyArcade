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
    //PlayerMediator playerMediator;
    ////능력 여부 
    //public bool onRide;
    //public bool canKick;

    //RaycastHit2D ray;
    //RaycastHit2D[] tilerays;
    //RaycastHit2D[] bombrays;


    //private void Start()
    //{
    //    playerMediator = GetComponentInParent<PlayerMediator>();
    //}
    ///// <summary>
    ///// Method : 플레이어가 탈 것을 탑승
    ///// </summary>
    //public void Ride()
    //{

    //}
    ///// <summary>
    ///// Method : 플레이어가 물풍선을 차는 능력. --> 물풍선이 플레이어의 앞에 있을 경우에만 작동
    ///// </summary>
    //public void Kick()
    //{
    //    if (!canKick) { return; }
    //    if (!playerMediator.playerInventory.Inven.Exists((gameObject_ => gameObject_.GetComponent<Shoes>()))) { return; }

    //    Bomb bomb = GetComponentInChildren<KickAbilityChecker>().targetBomb; //플레이어에게 붙은 폭탄. 즉 발로 차려는 목표 폭탄.
    //    int bombPosX = bomb.GetComponent<Bomb>().tileNode.posX; // bomb.GetComponent<Bomb>().tileNode.PosX -> 너무 길므로 요약표현.
    //    int bombPosY = bomb.GetComponent<Bomb>().tileNode.posY; // bomb.GetComponent<Bomb>().tileNode.PosY -> 너무 길므로 요약표현.

    //    Tile startTile = TileManager.Tile.tileDic[$"{bombPosX},{bombPosY}"];      //폭탄의 현재 타일 좌표. 레이캐스트가 시작될 위치 타일.

    //    Vector2 startPos = startTile.transform.position; //폭탄의 전역 공간 좌표.               


    //    switch (playerMediator.forwardGuide.Forward)
    //    {
    //        case ForwardGuide.ForwardState.up:
    //            CalculateKickPos(startPos, startTile.transform.up, bomb, 0, -1);
    //            break;
    //        case ForwardGuide.ForwardState.down:
    //            CalculateKickPos(startPos, -startTile.transform.up, bomb, 0, +1);
    //            break;

    //        case ForwardGuide.ForwardState.left:
    //            CalculateKickPos(startPos, -startTile.transform.right, bomb, 1, 0);
    //            break;

    //        case ForwardGuide.ForwardState.right:
    //            CalculateKickPos(startPos, startTile.transform.right, bomb, -1, 0);
    //            break;
    //    }

    //}

    ////Method : 신발로 폭탄을 찼을때 폭탄의 위치를 계산한다.
    //void CalculateKickPos(Vector2 rayStart, Vector2 rayDir, Bomb bomb, int x, int y)  // up : (0, -1) ,down : (0 ,+1),right : (-1,0), left (1,0)
    //{
    //    /*작동방식 개괄
    //     * 0. 레이캐스트로 선을 쏴봐서, 
    //     * 
    //     * 
    //     * 
    //     * 
    //     * 
    //     */



    //    ray = Physics2D.Raycast(rayStart, rayDir, 15f, wallmask); //0. 
    //    if (ray.collider != null && ray.collider.gameObject.GetComponent<BaseWall>())
    //    {
    //        ResetBombData(bomb, ray, x, y);
    //    }
    //    else if (ray.collider == null) //아무것도 없었을 경우.
    //    {
    //        bombrays = Physics2D.RaycastAll(rayStart, rayDir, 15f, bombmask); //경로에 폭탄이 있었을 경우 

    //        if (bombrays.Length >= 2)
    //        {
    //            TileNode tilenode_;
    //            tilenode_ = bombrays[bombrays.Length - 1].collider.gameObject.GetComponent<Bomb>().tileNode;

    //            bomb.StopExplodeCoroutine();
    //            bomb.PosX = tilenode_.posX + x;
    //            bomb.PosY = tilenode_.posY + y;
    //            bomb.transform.position = TileManager.Tile.tileDic[$"{bomb.PosX},{bomb.PosY}"].transform.position;
    //            bomb.StartExplodeCoroutine();
    //        }
    //        else //파괴불가능한 벽 혹은 몰라 ㅆㅂ
    //        {
    //            tilerays = Physics2D.RaycastAll(rayStart, rayDir, 15f, tilemask);

    //            if (tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>()) //마지막으로 타일 체크
    //            {
    //                Tile lastTile = tilerays[tilerays.Length - 1].collider.gameObject.GetComponent<Tile>();

    //                bomb.StopExplodeCoroutine();
    //                bomb.PosX = lastTile.tileNode.posX;
    //                bomb.PosY = lastTile.tileNode.posY;
    //                bomb.transform.position = TileManager.Tile.tileDic[$"{bomb.PosX},{bomb.PosY}"].transform.position;
    //                bomb.StartExplodeCoroutine();

    //            }
    //        }

    //    }
    //}
    //void ResetBombData(Bomb bomb, RaycastHit2D ray, int x, int y)
    //{
    //    TileNode tilenode_;
    //    if (ray.collider.GetComponent<BaseWall>())
    //    {
    //        tilenode_ = ray.collider.gameObject.GetComponent<BaseWall>().tileNode;
    //        bomb.StopExplodeCoroutine();
    //        bomb.PosX = tilenode_.posX + x;
    //        bomb.PosY = tilenode_.posY + y;
    //        bomb.transform.position = TileManager.Tile.tileDic[$"{tilenode_.posX + x},{tilenode_.posY + y}"].transform.position;
    //        bomb.StartExplodeCoroutine();
    //    }
    //}


}
