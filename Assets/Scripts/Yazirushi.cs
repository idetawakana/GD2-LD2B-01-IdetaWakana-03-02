using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yazirushi : MonoBehaviour
{
    private SelectManager selectManager;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectObj = GameObject.Find("SelectManager");
        selectManager = selectObj.GetComponent<SelectManager>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(selectManager.stageNum == 1)
        {
            pos.x = 437;
        }else if (selectManager.stageNum == 2)
        {
            pos.x = 796;
        }
        else if (selectManager.stageNum == 3)
        {
            pos.x = 1150;
        }

        transform.position = pos;
    }
}
