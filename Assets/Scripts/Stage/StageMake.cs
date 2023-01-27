using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMake : MonoBehaviour
{
    private StageSet stageSet;

    private CameraPos cameraPos;

    public float[,] stage;

    public GameObject floor;
    public GameObject block;

    private Vector3 pos;

    private bool isBuild;

    private float cameraX;

    enum TileType
    { 
        End = 0,
        Floor = 1,
        Wall = 2
    }

    private void Awake()
    {
        
        stageSet = GetComponent<StageSet>();
        stage = stageSet.stage;
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

                    if (stage[i,j] == 2)
                    {
                        Instantiate(floor, pos, Quaternion.identity);
                        pos.y = 0;
                        Instantiate(block, pos, Quaternion.identity);
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
        return stage[grid.x, grid.y] == (int)TileType.Floor;
    }

    public bool IsBlock(Vector2Int grid)
    {
        return stage[grid.x, grid.y] == (int)TileType.Wall ||
            stage[grid.x, grid.y] == (int)TileType.End;
    }
}
