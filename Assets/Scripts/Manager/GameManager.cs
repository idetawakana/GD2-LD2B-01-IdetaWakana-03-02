using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isClear;

    public float clearTimer;

    public GameObject clearText;

    public StageSelect stageSelect;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectObj = GameObject.Find("StageSelect");
        stageSelect = selectObj.GetComponent<StageSelect>();
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isClear == true)
        {
            if (clearTimer >= 1)
            {
                clearText.SetActive(true);
                clearTimer -= Time.deltaTime;
            }
            else if (clearTimer < 1)
            {
                stageSelect.stageNum++;
                if (stageSelect.stageNum <= 2)
                {
                    SceneReset();
                }
                else
                {
                    stageSelect.stageNum = 1;
                    SceneReset();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //stageSelect.stageNum++;
            SceneReset();
        }
    }

    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
    public void SceneReset()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
}
