using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerMove playerMove2;

    private GoalBox goalBox;
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
        if(other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            playerMove.levelRight += playerMove2.levelRight;
        }
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
            else
            {
                if (playerMove2.isBlockLeft == true)
                {
                    if (playerMove2.isLeft2 == true)
                    {
                        playerMove.isLeft2 = true;
                    }
                    else
                    {
                        playerMove.isLeft2 = false;
                    }
                }
            }
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();

            playerMove.isBlockLeft = true;

            if (goalBox.level <= playerMove.levelLeft)
            {
                playerMove.isLeft2 = true;
                goalBox.isLeft = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isLeft = true;
        if (other.tag == "Player")
        {
            playerMove.isLeft2 = false;
            playerMove.levelRight = 1;
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();
            goalBox.isLeft = false;
            playerMove.isLeft2 = false;
            playerMove.isBlockLeft = false;
        }
    }
}
