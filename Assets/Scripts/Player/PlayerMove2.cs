using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    private StageMake stageMake;

    private Vector3 pos;

    public bool isRight;
    public bool isLeft;
    public bool isBack;
    public bool isFront;

    // Start is called before the first frame update
    void Start()
    {
        GameObject stageObj = GameObject.Find("Stage");
        stageMake = stageObj.GetComponent<StageMake>();

        isRight = true;
        isLeft = true;
        isBack = true;
        isFront = true;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (stageMake.stage[Mathf.RoundToInt(pos.x) + 1, Mathf.RoundToInt(pos.z)] != 0)
            {
                if (isRight == true)
                {
                    pos.x += 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (stageMake.stage[Mathf.RoundToInt(pos.x) - 1, Mathf.RoundToInt(pos.z)] != 0)
            {
                if (isLeft == true)
                {
                    pos.x -= 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) + 1] != 0)
            {
                if (isBack == true)
                {
                    pos.z += 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (stageMake.stage[Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z) - 1] != 0)
            {
                if (isFront == true)
                {
                    pos.z -= 1;
                }
            }
        }

        transform.position = pos;
    }
}
