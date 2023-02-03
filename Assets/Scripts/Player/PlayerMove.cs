using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using static UnityEditor.PlayerSettings;
using static UnityEngine.Networking.UnityWebRequest;

public class PlayerMove : MonoBehaviour
{
    private StageMake stageMake;

    private StageSelect stageSelect;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

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

    public bool isLevelAdd;

    public bool isBlockRight;
    public bool isBlockLeft;
    public bool isBlockBack;
    public bool isBlockFront;

    public Dictionary<NextDirection, PlayerMove> nextPlayerMove;
    public Dictionary<NextDirection, GoalBlock> nextPlayerMoveBlock;

    private bool pushRightKey;
    private bool pushLeftKey;
    private bool pushUpKey;
    private bool pushDownKey;

    public Vector2Int grid;

    private bool isMoved;

    // public NextDirection direction;

    // Start is called before the first frame update
    void Start()
    {
        GameObject stageObj = GameObject.Find("Stage");
        stageMake = stageObj.GetComponent<StageMake>();

        nextPlayerMove = new Dictionary<NextDirection, PlayerMove>();
        nextPlayerMoveBlock = new Dictionary<NextDirection, GoalBlock>();

        GameObject selectObj = GameObject.Find("StageSelect");
        stageSelect = selectObj.GetComponent<StageSelect>();

        if (stageSelect.stageNum == 1)
        {
            transform.position = pos1;
        }
        else if (stageSelect.stageNum == 2)
        {
            transform.position = pos2;
        }
        else if (stageSelect.stageNum == 3)
        {
            transform.position = pos3;
        }

        //isRight = true;
        //isLeft = true;
        //isBack = true;
        //isFront = true;

        pushRightKey = false;
        pushLeftKey = false;
        pushUpKey = false;
        pushDownKey = false;

        CheckAllNextTile();
        isMoved = false;
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
        if (stageMake.IsBlock(GridOffset))//�X�e�[�W��̕ǁE�������̓i���N��������
        {
            return SetMovable(direction, false);//���̕����ւ͈ړ��ł��Ȃ��B
        }

        //if (gameObject.name == "Player" && direction == NextDirection.Right)
        //{
        //    Debug.Log("CheckNextTile Player");
        //}
        // direction�̌����ɗאڂ��Ă���ӏ��ɁAplayer�����邩�ۂ��B
        if (nextPlayerMove.ContainsKey(direction))
        {
            bool nextResult = nextPlayerMove[direction].CheckNextTile(direction);
            bool result = SetMovable(direction, nextResult);
            return result;
        }

        // direction�̌����ɗאڂ��Ă���ӏ��ɁA��Q�������邩�ۂ��B
        if (nextPlayerMoveBlock.ContainsKey(direction))
        {
            if (IsPushNextGoalBlock(direction))
            {
                return SetMovable(direction, nextPlayerMoveBlock[direction].CheckNextTile(direction));
            }
            else
            {
                return SetMovable(direction, false);
            }
        }

        if (stageMake.IsFloor(GetGrid(direction)))
        {
            return SetMovable(direction, true);//���̕����ւ͈ړ��ł��Ȃ��B
        }

        return false; //��O�Ȃ��͂�

    }

    // Update is called once per frame
    void Update()
    {
        grid = GetGrid(0, 0);
        UpdateNextGoalBlockCollision();
        CheckAllNextTile();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            //levelRight += 
        }

    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        if (isRight && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {

            pos.x += 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Right);

            isMoved = true;
        }

        if (isLeft && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            if (gameObject.name == "Player2")
            {
                Debug.Log("Player2 is moved to left");
            }
            pos.x -= 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Left);

            isMoved = true;

        }

        if (isBack && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            pos.z += 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Back);

            isMoved = true;

        }

        if (isFront && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            pos.z -= 1;
            transform.position = pos;
            PushNextGoalBlock(NextDirection.Front);

            isMoved = true;

        }
    }
    private void UpdateNextGoalBlockCollision()
    {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("GoalBlock");
        for (int i = 0; i < goals.Length; i++)
        {
            goals[i].GetComponent<GoalBlock>().CheckAllNextTile();
        }
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

        float pushLevel = GetPushLevel(moveDiretion);

        if (nextPlayerMoveBlock[moveDiretion].level <= pushLevel)
        {
            nextPlayerMoveBlock[moveDiretion].Push(moveDiretion);
        }
    }

    private bool IsPushNextGoalBlock(NextDirection moveDiretion)
    {
        float pushLevel = GetPushLevel(moveDiretion);

        return (nextPlayerMoveBlock[moveDiretion].level <= pushLevel);
    }

    //public float GetLevel(NextDirection direction)
    //{
    //    float level = 1;
    //    switch (direction)
    //    {
    //        case NextDirection.Right:
    //            level = levelRight;
    //            break;
    //        case NextDirection.Left:
    //            level = levelLeft;
    //            break;
    //        case NextDirection.Back:
    //            level = levelBack;
    //            break;
    //        case NextDirection.Front:
    //            level = levelFront;
    //            break;
    //        default:
    //            level = 1;
    //            break;
    //    }
    //    return level;
    //}

    private NextDirection GetBehind(NextDirection direction)
    {
        switch (direction)
        {
            case NextDirection.Right:
                return NextDirection.Left;
                break;
            case NextDirection.Left:
                return NextDirection.Right;
                break;
            case NextDirection.Back:
                return NextDirection.Front;
                break;
            case NextDirection.Front:
                return NextDirection.Back;
                break;
        }
        return NextDirection.LeftBack;
    }

    public float GetPushLevel(NextDirection direction)
    {
        float pushLevel = 1;

        if (nextPlayerMove.ContainsKey(GetBehind(direction)))
        {
            pushLevel += nextPlayerMove[GetBehind(direction)].GetPushLevel(direction);
        }
        return pushLevel;
    }
}
