using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBack : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerMove playerMove2;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = transform.parent.gameObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        playerMove.isBack = false;

        if (other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            if (playerMove2.isBack == true)
            {
                playerMove.isBack2 = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isBack = true;
    }
}
