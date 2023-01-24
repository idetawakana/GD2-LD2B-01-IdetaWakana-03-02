using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFront : MonoBehaviour
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
        playerMove.isFront = false;

        if (other.tag == "Player")
        {
            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
            if (playerMove2.isFront == true)
            {
                playerMove.isFront2 = true;
            }
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();
            if (goalBox.level <= playerMove.level)
            {
                playerMove.isFront2 = true;
                goalBox.isFront = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isFront = true;

        if(other.tag == "Player")
        {
            playerMove.isFront2 = false;
        }

        if (other.tag == "GoalBox")
        {
            goalBox = other.gameObject.GetComponent<GoalBox>();
            goalBox.isFront = false;
            playerMove.isFront2 = false;
        }
    }
}
