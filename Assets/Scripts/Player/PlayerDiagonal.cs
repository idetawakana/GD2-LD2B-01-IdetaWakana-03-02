using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiagonal : MonoBehaviour
{
    private PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = transform.parent.gameObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
            
    //    }
    //}
}
