using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        playerMove.isLeft = false;

        if (other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            if (playerMove2.isLeft == true)
            {
                playerMove.isLeft2 = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isLeft = true;
        if (other.tag == "Player")
        {
            playerMove.isLeft2 = false;
        }
    }
}
