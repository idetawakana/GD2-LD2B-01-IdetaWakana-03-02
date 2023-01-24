using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRight : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        playerMove.isRight = false;

        if (other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            if (playerMove2.isRight == true)
            {
                playerMove.isRight2 = true;
            }
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();
            if (goalBox.level <= playerMove.level)
            {
                playerMove.isRight2 = true;
                goalBox.isRight = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isRight = true;

        if (other.tag == "Player")
        {
            playerMove.isRight2 = false;
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();
            goalBox.isRight = false;
            playerMove.isRight2 = false;
        }
    }
}
