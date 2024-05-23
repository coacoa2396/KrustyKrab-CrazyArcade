using pakjungmin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
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
    public bool canKick;

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
    /// Method : 플레이어가 물풍선을 차는 능력. --> 물풍선이 플레이어의 앞에 있을 경우에만 작동
    /// </summary>
    public void Kick()
    {
        if (!canKick) { return; }
        if (!playerMediator.playerInventory.Inven.Exists((gameObject_ => gameObject_.GetComponent<Shoes>()))) { return; }

        Bomb bomb = GetComponentInChildren<KickAbilityChecker>().targetBomb; //플레이어에게 붙은 폭탄. 즉 발로 차려는 목표 폭탄.
        int bombPosX = bomb.GetComponent<Bomb>().tileNode.posX; // bomb.GetComponent<Bomb>().tileNode.PosX -> 너무 길므로 요약표현.
        int bombPosY = bomb.GetComponent<Bomb>().tileNode.posY; // bomb.GetComponent<Bomb>().tileNode.PosY -> 너무 길므로 요약표현.

       Debug.Log($"Origin : (({bombPosX},{bombPosY}))");

        Tile startTile = TileManager.Tile.tileDic[$"{bombPosX},{bombPosY}"];      //폭탄의 현재 타일 좌표. 레이캐스트가 시작될 위치 타일.

        Vector2 startPos = startTile.transform.position; //폭탄의 전역 공간 좌표.               


        switch (playerMediator.forwardGuide.Forward)
        {
            case ForwardGuide.ForwardState.up:
                CalculateKickPos(startPos, startTile.transform.up, bomb,ForwardGuide.ForwardState.up);
                break;
            case ForwardGuide.ForwardState.down:
                CalculateKickPos(startPos, -startTile.transform.up, bomb,ForwardGuide.ForwardState.down);
                break;

            case ForwardGuide.ForwardState.left:
                CalculateKickPos(startPos, -startTile.transform.right, bomb,ForwardGuide.ForwardState.left);
                break;

            case ForwardGuide.ForwardState.right:
                CalculateKickPos(startPos, startTile.transform.right, bomb,ForwardGuide.ForwardState.right);
                break;
        }

    }

    //Method : 신발로 폭탄을 찼을때 폭탄의 위치를 계산한다.
    void CalculateKickPos(Vector2 rayStart, Vector2 rayDir, Bomb bomb,ForwardGuide.ForwardState state)
    {
        RaycastHit2D[] raycasthit_Tiles;

        int tileLayerMask = 1 << LayerMask.NameToLayer("Tile"); // --->레이캐스트와 레이어마스크 복습 필요.

        raycasthit_Tiles = Physics2D.RaycastAll(rayStart, rayDir, 15f,tileLayerMask);

        if (raycasthit_Tiles != null)
        {
            Tile[] tileArray = new Tile[raycasthit_Tiles.Length];
            for (int a = 0; a < raycasthit_Tiles.Length; a++)
            {
                if (raycasthit_Tiles[a].collider.GetComponent<Tile>() != null)
                {
                    tileArray[a] = raycasthit_Tiles[a].collider.GetComponent<Tile>(); //tlqkf
                }
            }

            if(!Array.Exists<Tile>(tileArray,item => item != null)){ Debug.Log("타일이 없습니다."); return; }

            else
            {
                //타일 경로 상에 빈 타일이 있음. 타일어레이는 먼 타일부터 가까운 타일 순서대로.
                //먼타일이 null인지 계산하고, null이면 나머지타일이 null인지를 계산한다. 하나라도 널이 아니면 넘어간다.
                for (int a = 0; a < tileArray.Length; a++) //0,1,2,3,4
                {
                    if (a == 4)
                    {
                        Debug.Log("폭탄 앞의 모든 타일이 이동불가능하다.");
                        return;
                    }

                    if (!tileArray[tileArray.Length-(a+1)].OnObject) //타겟 타일이 비어있다면.
                    {
                        if (a < 4)
                        { //타겟 타일이 비어있다는 건 확인했으니, 이제 그 타일 사이의 경로가 뚫려있는지 알아야한다.
                            int isPassed = Array.FindIndex<Tile>(tileArray, 0, tileArray.Length - (a + 2), item => item.OnObject);

                            if (isPassed != -1) //조건을 만족한다면
                            {
                                Debug.Log($"{bomb.PosX},{bomb.PosY} => ({tileArray[a].tileNode.posX},{tileArray[a].tileNode.posX})");
                                TransformBomb(tileArray[a], bomb);
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }   
            }
        }
    }
    void TransformBomb(Tile newTile,Bomb bomb)
    {
        bomb.StopExplodeCoroutine();
        bomb.PosX = newTile.tileNode.posX;
        bomb.PosY = newTile.tileNode.posY;
        bomb.transform.position = TileManager.Tile.tileDic[$"{bomb.PosX},{bomb.PosY}"].transform.position;
        bomb.StartExplodeCoroutine();
    }
}
    

