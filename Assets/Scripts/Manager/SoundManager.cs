using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //public AudioSource gameBGM;
    public AudioSource clearSE;
    public AudioSource moveSE;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
