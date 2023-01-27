using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

public class PlayerMove : MonoBehaviour
{
    private StageMake stageMake;


    public bool isRight;
    public bool isRight2;

    public bool isLeft;
    public bool isLeft2;

    public bool isBack;
    public bool isBack2;

    public bool isFront;
    public bool isFront2;

    public float level;

    public float levelRight;
    public float levelLeft;
    public float levelBack;
    public float levelFront;

    public bool isBlockRight;
    public bool isBlockLeft;
    public bool isBlockBack;
    public bool isBlockFront;

    public Dictionary<NextDirection, PlayerMove> nextPlayerMove;
    public Dictionary<NextDirection, GoalBlock> nextPlayerMoveBlock;

    // public NextDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject stageObj = GameObject.Find("Stage");
        stageMake = stageObj.GetComponent<StageMake>();

        nextPlayerMove = new Dictionary<NextDirection, PlayerMove>();
        nextPlayerMoveBlock = new Dictionary<NextDirection, GoalBlock>();

        //isRight = true;
        //isLeft = true;
        //isBack = true;
        //isFront = true;

        CheckAllNextTile();
    }

    public void CheckAllNextTile()
    {
        CheckNextTile(NextDirection.Left);
        CheckNextTile(NextDirection.Right);
        CheckNextTile(NextDirection.Front);
        CheckNextTile(NextDirection.Back);

        //Debug.Log("NowGridPosition:" + GetGrid(0, 0));
        //Debug.Log("NextPlayerMovesCount" + nextPlayerMove.Count);
        //Debug.Log("NextGoal" + nextPlayerMoveBlock.Count);
    }

    public bool CheckNextTile(NextDirection direction)
    {

        Vector2Int GridOffset = GetGrid(direction);
        if (stageMake.IsBlock(GridOffset))//ステージ上の壁・もしくはナラクだったら
        {
            return SetMovable(direction, false);//その方向へは移動できない。
        }

        // directionの向きに隣接している箇所に、障害物があるか否か。
        if (nextPlayerMove.ContainsKey(direction))
        {
            bool nextResult = nextPlayerMove[direction].CheckNextTile(direction);
            bool result = SetMovable(direction, nextResult);
            return result;
        }

        // directionの向きに隣接している箇所に、障害物があるか否か。
        if (nextPlayerMoveBlock.ContainsKey(direction))
        {
            return SetMovable(direction, nextPlayerMoveBlock[direction].CheckNextTile(direction));
        }

        if (stageMake.IsFloor(GetGrid(direction)))
        {
            return SetMovable(direction, true);//その方向へは移動できない。
        }

        return false; //例外ないはず

    }

    // Update is called once per frame
    void Update()
    {

        ////player
        //isRight = !nextPlayerMove.ContainsKey(NextDirection.Right);
        //if (nextPlayerMove.ContainsKey(NextDirection.Right))
        //{
        //    if (nextPlayerMove[NextDirection.Right].isRight == true)
        //    {
        //        isRight2 = true;
        //    }
        //    else
        //    {
        //        if (nextPlayerMove[NextDirection.Right].isBlockRight == true)
        //        {
        //            if (nextPlayerMove[NextDirection.Right].isRight2 == true)
        //            {
        //                isRight2 = true;
        //            }
        //            else
        //            {
        //                isRight2 = false;
        //            }
        //        }
        //        else
        //        {
        //            if (nextPlayerMove[NextDirection.Right].isRight2 == true)
        //            {
        //                isRight2 = true;
        //            }
        //            else
        //            {
        //                isRight2 = false;
        //            }
        //        }
        //    }
        //}

        //isLeft = !nextPlayerMove.ContainsKey(NextDirection.Left);
        //isBack = !nextPlayerMove.ContainsKey(NextDirection.Back);
        //isFront = !nextPlayerMove.ContainsKey(NextDirection.Front);



        ////block
        //isRight = !nextPlayerMoveBlock.ContainsKey(NextDirection.Right);
        //if (nextPlayerMoveBlock.ContainsKey(NextDirection.Right))
        //{
        //    isBlockRight = true;

        //    if (nextPlayerMoveBlock[NextDirection.Right].level <= levelRight)
        //    {
        //        isRight2 = true;
        //        nextPlayerMoveBlock[NextDirection.Right].isRight = true;
        //    }
        //}

        //isLeft = !nextPlayerMoveBlock.ContainsKey(NextDirection.Left);
        //if (nextPlayerMoveBlock.ContainsKey(NextDirection.Left))
        //{
        //    isBlockLeft = true;
        //}

        //isBack = !nextPlayerMoveBlock.ContainsKey(NextDirection.Back);
        //if (nextPlayerMoveBlock.ContainsKey(NextDirection.Back))
        //{
        //    isBlockBack = true;
        //}

        //isFront = !nextPlayerMoveBlock.ContainsKey(NextDirection.Front);
        //if (nextPlayerMoveBlock.ContainsKey(NextDirection.Front))
        //{
        //    isBlockFront = true;
        //}


        Vector3 pos = transform.position;

        if (isRight && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            pos.x += 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Right);

            CheckAllNextTile();

        }



        //if (stageMake.IsFloor(GetGrid(2, 0)))
        //{
        //    //pos.x += 1;
        //}
        //else
        //{
        //    isRight2 = false;
        //}

        if (isLeft && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            pos.x -= 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Left);

            CheckAllNextTile();

        }
        //if (stageMake.stage[Mathf.RoundToInt(pos.x) - 2, Mathf.RoundToInt(pos.z)] == 1)
        //{
        //    //pos.x -= 1;
        //}
        //else
        //{
        //    isLeft2 = false;
        //}

        if (isBack && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            pos.z += 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Back);

            CheckAllNextTile();

        }

        //if (stageMake.IsFloor(GetGrid(0, 2)))
        //{
        //    //pos.z += 1;
        //}
        //else
        //{
        //    isBack2 = false;
        //}

        if (isFront && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            pos.z -= 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Front);

            CheckAllNextTile();

        }

        //if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) - 2] == 1)
        //{
        //    //pos.z -= 1;
        //}
        //else
        //{
        //    isFront2 = false;
        //}

    }


    public bool SetMovable(NextDirection direction, bool isMovable)
    {
        switch (direction)
        {
            case NextDirection.Right:
                isRight = isMovable;
                break;
            case NextDirection.Left:
                isLeft = isMovable;
                break;
            case NextDirection.Back:
                isBack = isMovable;
                break;
            case NextDirection.Front:
                isFront = isMovable;
                break;
            default:
                break;
        }
        return isMovable;
    }

    public bool GetMovable(NextDirection direction)
    {
        switch (direction)
        {
            case NextDirection.Right:
                return isRight;
            case NextDirection.Left:
                return isLeft;
            case NextDirection.Back:
                return isBack;
            case NextDirection.Front:
                return isFront;
            default:
                return false;
        }
    }



    public void SetNextPlayerMove(NextDirection direction, PlayerMove playerMove)
    {
        nextPlayerMove.Add(direction, playerMove);
        CheckAllNextTile();

    }

    public void RemoveNextPlayerMove(NextDirection direction)
    {
        nextPlayerMove.Remove(direction);
        CheckAllNextTile();

    }

    public void SetNextPlayerMoveBlock(NextDirection direction, GoalBlock goalBlock)
    {
        nextPlayerMoveBlock.Add(direction, goalBlock);
        CheckAllNextTile();
    }

    public void RemoveNextPlayerMoveBlock(NextDirection direction)
    {
        nextPlayerMoveBlock.Remove(direction);
        //Debug.Log("RemoveNextPlayerMoveBlock[" + direction + "]");
        CheckAllNextTile();
    }

    private Vector2Int GetGrid(int offsetX, int offsetZ)
    {
        Vector3 pos = transform.position;
        Vector2Int result =
            new Vector2Int(Mathf.RoundToInt(pos.x) + offsetX, Mathf.RoundToInt(pos.z) + offsetZ);
//        Debug.Log("Name:"+gameObject.name+" Position:" + pos);
        //Debug.Log("PositionX:" + (result.x - offsetX) + "<-" + pos.x + "\nPositionZ" + (result.y - offsetZ) + "<-" + pos.z);
        return result;
    }
    private Vector2Int GetGrid(NextDirection direction)
    {
        Vector2Int offset;
        switch (direction)
        {
            case NextDirection.Right:
                offset = new Vector2Int(1, 0);
                break;
            case NextDirection.Left:
                offset = new Vector2Int(-1, 0);
                break;
            case NextDirection.Back:
                offset = new Vector2Int(0, 1);
                break;
            case NextDirection.Front:
                offset = new Vector2Int(0, -1);
                break;
            default:
                offset = new Vector2Int(0, 0);
                break;
        }
        return GetGrid(offset.x, offset.y);
    }

    private void PushNextGoalBlock(NextDirection moveDiretion)
    {
        if (!nextPlayerMoveBlock.ContainsKey(moveDiretion)) { return; }
        nextPlayerMoveBlock[moveDiretion].Push(moveDiretion);
    }
}
