using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    //public AudioSource gameBGM;
    public AudioSource clearSE;
    public AudioSource moveSE;
    public AudioSource selectSE;
    public AudioSource titleBGM;
    public AudioSource gameBGM;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "StageSelect")
        {
            titleBGM.Play();
        }else if(SceneManager.GetActiveScene().name == "SampleScene")
        {
            gameBGM.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayClearSE()
    {
        clearSE.Play();
    }

    public void PlayMoveSE()
    {
        moveSE.Play();
    }

    public void PlaySelectSE()
    {
        selectSE.Play();
    }
}
