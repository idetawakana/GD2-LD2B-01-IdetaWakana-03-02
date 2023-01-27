using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBack : MonoBehaviour
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
        if (other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            playerMove.levelFront += playerMove2.levelFront;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        playerMove.isBack = false;

        if (other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            if (playerMove2.isBack == true)
            {
                playerMove.isBack2 = true;
            }
            else
            {
                if (playerMove2.isBlockBack == true)
                {
                    if (playerMove2.isBack2 == true)
                    {
                        playerMove.isBack2 = true;
                    }
                    else
                    {
                        playerMove.isBack2 = false;
                    }
                }
            }
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();

            playerMove.isBlockBack = true;

            if (goalBox.level <= playerMove.levelBack)
            {
                playerMove.isBack2 = true;
                goalBox.isBack = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isBack = true;

        if (other.tag == "Player")
        {
            playerMove.isBack2 = false;
            playerMove.levelFront = 1;
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();
            goalBox.isBack = false;
            playerMove.isBack2 = false;
            playerMove.isBlockBack = false;
        }
    }
}
