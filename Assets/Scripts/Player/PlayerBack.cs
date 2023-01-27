//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerBack : MonoBehaviour
//{
//    private PlayerMove playerMove;
//    private PlayerMove playerMove2;
//    private PlayerMove playerMove3;

//    private PlayerCollider playerCollider;

//    private GoalBlock GoalBlock;

//    // Start is called before the first frame update
//    void Start()
//    {
//        playerMove = transform.parent.gameObject.GetComponent<PlayerMove>();

//        playerCollider = transform.parent.gameObject.GetComponent<PlayerCollider>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        //if (other.tag == "Player")
//        //{
//        //    playerMove2 = other.gameObject.GetComponent<PlayerMove>();
//        //    playerMove.levelFront += playerMove2.levelFront;
//        //}

//        if (other.tag == "Player")
//        {
//            playerMove3 = other.gameObject.GetComponent<PlayerMove>();

//            playerCollider.nextPlayerMove.Add(PlayerCollider.NextDirection.Back, playerMove);
//        }
//    }

//    private void OnTriggerStay(Collider other)
//    {
//        //playerMove.isBack = false;

//        if (other.tag == "Player")
//        {
//            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
//            if (playerMove2.isBack == true)
//            {
//                playerMove.isBack2 = true;
//            }
//            else
//            {
//                if (playerMove2.isBlockBack == true)
//                {
//                    if (playerMove2.isBack2 == true)
//                    {
//                        playerMove.isBack2 = true;
//                    }
//                    else
//                    {
//                        playerMove.isBack2 = false;
//                    }
//                }
//            }
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();

//            playerMove.isBlockBack = true;

//            if (GoalBlock.level <= playerMove.levelBack)
//            {
//                playerMove.isBack2 = true;
//                GoalBlock.isBack = true;
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        //playerMove.isBack = true;

//        if (other.tag == "Player")
//        {
//            playerMove.isBack2 = false;
//            playerMove.levelFront = 1;
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();
//            GoalBlock.isBack = false;
//            playerMove.isBack2 = false;
//            playerMove.isBlockBack = false;
//        }

//        if (other.tag == "Player")
//        {
//            playerCollider.nextPlayerMove.Remove(PlayerCollider.NextDirection.Back);
//        }
//    }
//}
