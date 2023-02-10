using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isClear;

    public float clearTimer;

    public GameObject clearText;

    public SelectManager selectManager;

    private SoundManager soundManager;

    //public AudioSource clearSE;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectObj = GameObject.Find("SelectManager");
        selectManager = selectObj.GetComponent<SelectManager>();

        GameObject soundObj = GameObject.Find("SoundManager");
        soundManager = soundObj.GetComponent<SoundManager>();

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
                selectManager.stageNum++;
                if (selectManager.stageNum <= 3)
                {
                    SceneReset();
                }
                else
                {
                    //selectManager.stageNum = 1;
                    ChangeScene("StageSelect");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //selectManager.stageNum++;
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

    //public void PlayClearSE()
    //{
    //    clearSE.Play();
    //}
}
