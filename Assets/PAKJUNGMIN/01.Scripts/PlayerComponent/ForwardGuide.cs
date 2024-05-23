using pakjungmin;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ForwardGuide : MonoBehaviour
{
   public enum ForwardState
    {
        up,
        down,
        left,
        right
    }
    PlayerMediator playerMediator;
    public Bomb targetBomb;

    ForwardState forwardState;

    public ForwardState Forward { get { return forwardState; } }

    public void ChangeForward(ForwardState state)
    {
        forwardState = state;
        switch (forwardState)
        {
            case ForwardState.up:
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 0.2f, 0);
                break;
            case ForwardState.down:
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y - 0.5f, 0);
                break;
            case ForwardState.left:
                transform.position = new Vector3(transform.parent.position.x + 0.4f, transform.parent.position.y, 0);
                break;
            case ForwardState.right:
                transform.position = new Vector3(transform.parent.position.x - 0.4f, transform.parent.position.y, 0);
                break;
        }
    }

    private void Start()
    {
        playerMediator = GetComponentInParent<PlayerMediator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BombPlayerDectector>())
        {
            if (collision.gameObject.GetComponent<BombPlayerDectector>().IsActive)
            {
                playerMediator.playerAbility.canKick = true;
                targetBomb = collision.transform.parent.GetComponent<Bomb>();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BombPlayerDectector>())
        {
            playerMediator.playerAbility.canKick = false;

            targetBomb = null;
        }
    }
}
