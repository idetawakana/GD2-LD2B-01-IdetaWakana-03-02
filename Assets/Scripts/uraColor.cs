using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uraColor : MonoBehaviour
{
    private SelectManager selectManager;

    public RawImage ura1;
    public RawImage ura2;
    public RawImage ura3;
    public RawImage ura4;

    private float timer;
    private bool stage1;
    private bool stage2;
    private bool stage3;
    private bool stage4;

    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        GameObject selectObj = GameObject.Find("SelectManager");
        selectManager = selectObj.GetComponent<SelectManager>();

        color = ura1.color;

        //ura1.GetComponent<RawImage>();
        //ura2.GetComponent<RawImage>();
        //ura3.GetComponent<RawImage>();
        //ura4.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectManager.stageNum == 1)
        {
            timer = 1;
            ura1.color = Color.white;
            stage1 = true;
        }else if (selectManager.stageNum == 2)
        {
            timer = 1;
            ura2.color = Color.white;
            stage2 = true;
        }
        else if (selectManager.stageNum == 3)
        {
            timer = 1;
            ura3.color = Color.white;
            stage3 = true;
        }
        else if (selectManager.stageNum == 4)
        {
            timer = 1;
            ura4.color = Color.white;
            stage4 = true;
        }

        if(stage1 == true)
        {
            if(timer <= 1)
            {
                if (ura1.color == color)
                {
                    ura1.color = Color.white;
                }
                else
                {
                    ura1.color =color;
                }
            }
            else
            {
                timer = 1;
            }
        }else if (stage2 == true)
        {
            if (timer <= 1)
            {
                if (ura2.color == color)
                {
                    ura2.color = Color.white;
                }
                else
                {
                    ura2.color =color;
                }
            }
            else
            {
                timer = 1;
            }
        }
        else if (stage3 == true)
        {
            if (timer <= 1)
            {
                if (ura3.color == color)
                {
                    ura3.color = Color.white;
                }
                else
                {
                    ura3.color = color;
                }
            }
            else
            {
                timer = 1;
            }
        }
        else if (stage4 == true)
        {
            if (timer <= 1)
            {
                if (ura4.color == color)
                {
                    ura4.color = Color.white;
                }
                else
                {
                    ura4.color = color;
                }
            }
            else
            {
                timer = 1;
            }
        }
    }
}
