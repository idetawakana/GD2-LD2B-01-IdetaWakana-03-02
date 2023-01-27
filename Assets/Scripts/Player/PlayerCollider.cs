using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerMove myPlayerMove;
    //public Dictionary<Direction, PlayerMove> nextPlayerMove; //���S�������ێ�����B
    private PlayerMove nextPlayerMove;

    private GoalBlock nextGoalBlock;

    public NextDirection myDirection;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerMove = transform.parent.gameObject.GetComponent<PlayerMove>();
        //        nextPlayerMove = new Dictionary<Direction, PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void SetMovable1(bool isMovable)
    //{
    //    switch (direction)
    //    {
    //        case Direction.Right:
    //            myPlayerMove.isRight = isMovable;
    //            break;
    //        case Direction.Left:
    //            myPlayerMove.isLeft = isMovable;
    //            break;
    //        case Direction.Back:
    //            myPlayerMove.isBack = isMovable;
    //            break;
    //        case Direction.Front:
    //            myPlayerMove.isFront = isMovable;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public void SetMovable2(bool isMovable)
    //{
    //    switch (direction)
    //    {
    //        case Direction.Right:
    //            playerMove2.isRight = isMovable;
    //            break;
    //        case Direction.Left:
    //            playerMove2.isLeft = isMovable;
    //            break;
    //        case Direction.Back:
    //            playerMove2.isBack = isMovable;
    //            break;
    //        case Direction.Front:
    //            playerMove2.isFront = isMovable;
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //public void SetNextPlayerMove(PlayerMove playerMove)
    //{
    //    myPlayerMove.SetNextPlayerMove(myDirection, playerMove);
    //}

    private void OnTriggerEnter(Collider other)
    {
//        Debug.Log("OnTrigger from ["+gameObject.name+"] to ["+other.name+"]:tag["+other.tag+"]");
        if (other.tag == "Player")
        {
            nextPlayerMove = other.gameObject.GetComponent<PlayerMove>();
            myPlayerMove.SetNextPlayerMove(myDirection, nextPlayerMove);
        }

        if(other.tag == "GoalBlock")
        {
            nextGoalBlock = other.gameObject.GetComponent<GoalBlock>();
            myPlayerMove.SetNextPlayerMoveBlock(myDirection, nextGoalBlock);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            nextPlayerMove = other.gameObject.GetComponent<PlayerMove>();
            myPlayerMove.RemoveNextPlayerMove(myDirection);
        }

        if (other.tag == "GoalBlock")
        {
            nextGoalBlock = other.gameObject.GetComponent<GoalBlock>();
            myPlayerMove.RemoveNextPlayerMoveBlock(myDirection);
        }
    }
}