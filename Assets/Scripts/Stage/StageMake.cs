using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMake : MonoBehaviour
{
    private StageSet stageSet;

    private CameraPos cameraPos;

    private SelectManager selectManager;

    public float[,] stage;

    public GameObject floor;
    public GameObject block;
    public GameObject clear;

    private Vector3 pos;

    private bool isBuild;

    private float cameraX;

    enum TileType
    {
        End = 0,
        Floor = 1,
        Wall = 2,
        Clear = 3
    }

    private void Awake()
    {

        stageSet = GetComponent<StageSet>();

        GameObject selectObj = GameObject.Find("SelectManager");
        selectManager = selectObj.GetComponent<SelectManager>();

        if (selectManager.stageNum == 1)
        {
            stage = stageSet.stage1;
        }
        else if (selectManager.stageNum == 2)
        {
            stage = stageSet.stage2;
        }
        else if (selectManager.stageNum == 3)
        {
            stage = stageSet.stage3;
        }
        else if (selectManager.stageNum == 4)
        {
            stage = stageSet.stage4;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        GameObject cameraObj = GameObject.Find("Main Camera");
        cameraPos = cameraObj.GetComponent<CameraPos>();


        isBuild = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBuild == false)
        {
            for (int i = 0; i < stage.GetLength(0); i++)
            {
                for (int j = 0; j < stage.GetLength(1); j++)
                {
                    pos = new Vector3(i, -1, j);
                    if (stage[i, j] == 1)
                    {
                        Instantiate(floor, pos, Quaternion.identity);
                    }

                    if (stage[i, j] == 2)
                    {
                        Instantiate(floor, pos, Quaternion.identity);
                        pos.y = 0;
                        Instantiate(block, pos, Quaternion.identity);
                    }

                    if (stage[i,j] == 3)
                    {
                        Instantiate(floor, pos, Quaternion.identity);
                        pos.y = 0;
                        Instantiate(clear, pos, Quaternion.identity);
                    }
                }
            }

            cameraX = stage.GetLength(0) / 2;

            cameraPos.SetCamera(cameraX);

            isBuild = true;
        }
    }

    public bool IsFloor(Vector2Int grid)
    {
        return stage[grid.x, grid.y] == (int)TileType.Floor || stage[grid.x,grid.y] == (int)TileType.Clear;
    }

    public bool IsBlock(Vector2Int grid)
    {
        return stage[grid.x, grid.y] == (int)TileType.Wall ||
            stage[grid.x, grid.y] == (int)TileType.End;
    }
}
