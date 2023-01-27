using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSet : MonoBehaviour
{
    public float[,] stage = new float[,]
    {
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,1,1,1,1,1,0,0},
        {0,0,1,1,1,1,1,0,0},
        {0,0,1,1,1,1,2,0,0},
        {0,0,1,1,1,1,1,0,0},
        {0,0,1,1,1,1,1,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
