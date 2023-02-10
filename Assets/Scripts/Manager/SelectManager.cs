using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    private SoundManager soundManager;

    public int stageNum;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        stageNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject soundObj = GameObject.Find("SoundManager");
        soundManager = soundObj.GetComponent<SoundManager>();

        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                soundManager.PlaySelectSE();

                if (stageNum == 3)
                {
                    stageNum = 1;
                }
                else
                {
                    stageNum++;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                soundManager.PlaySelectSE();

                if (stageNum == 1)
                {
                    stageNum = 3;
                }
                else
                {
                    stageNum--;
                }
            }

            if (stageNum > 3)
            {
                stageNum = 3;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeScene("SampleScene");
            }
        }

        //if (SceneManager.GetActiveScene().name == "Stage")
        //{
        //    if(stageNum == 8)
        //    {
        //        ChangeScene("StageSelect");
        //    }
        //}

    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
