using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMake : MonoBehaviour
{
    private StageSet stageSet;

    private CameraPos cameraPos;

    public float[,] stage;

    public GameObject floor;

    private Vector3 pos;

    private bool isBuild;

    private float cameraX;
    // Start is called before the first frame update
    void Start()
    {
        stageSet = GetComponent<StageSet>();

        GameObject cameraObj = GameObject.Find("Main Camera");
        cameraPos = cameraObj.GetComponent<CameraPos>();

        stage = stageSet.stage;

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
                }
            }

            cameraX = stage.GetLength(0) / 2;

            cameraPos.SetCamera(cameraX);

            isBuild = true;
        }
    }
}
