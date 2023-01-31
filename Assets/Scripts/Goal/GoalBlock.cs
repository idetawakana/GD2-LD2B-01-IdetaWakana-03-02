using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GoalBlock : MonoBehaviour
{
    private StageMake stageMake;

    private StageSelect stageSelect;

    public GameManager gameManager;

    private Vector3 pos;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

    public float level;

    public float level1;
    public float level2;
    public float level3;

    public bool isRight;
    public bool isLeft;
    public bool isBack;
    public bool isFront;

    public Dictionary<NextDirection, GoalBlock> nextPlayerMoveBlock;



    // Start is called before the first frame update
    void Start()
    {
        GameObject stageObj = GameObject.Find("Stage");
        stageMake = stageObj.GetComponent<StageMake>();

        GameObject selectObj = GameObject.Find("StageSelect");
        stageSelect = selectObj.GetComponent<StageSelect>();

        nextPlayerMoveBlock = new Dictionary<NextDirection, GoalBlock>();

        if (stageSelect.stageNum == 1)
        {
            transform.position = pos1;
            level = level1;
        }
        else if (stageSelect.stageNum == 2)
        {
            transform.position = pos2;
            level = level2;
        }
        else if (stageSelect.stageNum == 3)
        {
            transform.position = pos3;
            level = level3;
        }
    }

    public bool CheckNextTile(NextDirection direction)
    {

        Vector2Int GridOffset = GetGrid(direction);
        if (stageMake.IsBlock(GridOffset))//ステージ上の壁・もしくはナラクだったら
        {
            return SetMovable(direction, false);//その方向へは移動できない。
        }

        // TODO: ゴールブロックも、付近のゴールブロックを探す必要があるため、四方向の当たり判定が必要。
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
        //pos = transform.position;

        //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        //{
        //    if (stageMake.stage[Mathf.RoundToInt(pos.x) + 1, Mathf.RoundToInt(pos.z)] == 1)
        //    {
        //        if (isRight == true)
        //        {
        //            pos.x += 1;
        //        }
        //        //else
        //        //{
        //        //    if (isRight2 == true)
        //        //    {
        //        //        if (stageMake.stage[Mathf.RoundToInt(pos.x) + 2, Mathf.RoundToInt(pos.z)] == 1)
        //        //        {
        //        //            pos.x += 1;
        //        //        }
        //        //    }
        //        //}
        //    }
        //}


        //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        //{
        //    if (stageMake.stage[Mathf.RoundToInt(pos.x) - 1, Mathf.RoundToInt(pos.z)] == 1)
        //    {
        //        if (isLeft == true)
        //        {
        //            pos.x -= 1;
        //        }
        //        //else
        //        //{
        //        //    if (isLeft2 == true)
        //        //    {
        //        //        if (stageMake.stage[Mathf.RoundToInt(pos.x) - 2, Mathf.RoundToInt(pos.z)] == 1)
        //        //        {
        //        //            pos.x -= 1;
        //        //        }
        //        //    }
        //        //}
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        //{
        //    if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) + 1] == 1)
        //    {
        //        if (isBack == true)
        //        {
        //            pos.z += 1;
        //        }
        //        //else
        //        //{
        //        //    if (isBack2 == true)
        //        //    {
        //        //        if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) + 2] == 1)
        //        //        {
        //        //            pos.z += 1;
        //        //        }
        //        //    }
        //        //}
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        //{
        //    if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) - 1] == 1)
        //    {
        //        if (isFront == true)
        //        {
        //            pos.z -= 1;
        //        }
        //        //else
        //        //{
        //        //    if (isFront2 == true)
        //        //    {
        //        //        if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) - 2] == 1)
        //        //        {
        //        //            pos.z -= 1;
        //        //        }
        //        //    }
        //        //}
        //    }
        //}

        //transform.position = pos;

    }

    public void Push(NextDirection direction)
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3();
        switch (direction)
        {
            case NextDirection.Right:
                velocity.x = 1;
                break;
            case NextDirection.Left:
                velocity.x = -1;
                break;
            case NextDirection.Back:
                velocity.z = 1;
                break;
            case NextDirection.Front:
                velocity.z = -1;
                break;
            default:
                break;
        }
        transform.position = pos + velocity;
    }
    private Vector2Int GetGrid(int offsetX, int offsetZ)
    {
        Vector3 pos = transform.position;
        Vector2Int result =
            new Vector2Int(Mathf.RoundToInt(pos.x) + offsetX,
            Mathf.RoundToInt(pos.z) + offsetZ);
        Debug.Log("Name:" + gameObject.name + " Position:" + pos);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Clear")
        {
            gameManager.isClear = true;
        }
    }
}