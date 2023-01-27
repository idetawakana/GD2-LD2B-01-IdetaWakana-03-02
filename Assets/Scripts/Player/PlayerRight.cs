//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerRight : MonoBehaviour
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
//        //    playerMove.levelLeft += playerMove2.levelLeft;
//        //}

//        if (other.tag == "Player")
//        {
//            playerMove3 = other.gameObject.GetComponent<PlayerMove>();

//            playerCollider.nextPlayerMove.Add(PlayerCollider.NextDirection.Right, playerMove);

//            //playerCollider.direction = PlayerCollider.Direction.Right;
//            //playerCollider.SetMovable1(false);
//        }
//    }

//    private void OnTriggerStay(Collider other)
//    {
//        //playerMove.isRight = false;

//        if (other.tag == "Player")
//        {
//            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
//            if (playerMove2.isRight == true)
//            {
//                playerMove.isRight2 = true;
//            }
//            else
//            {
//                if(playerMove2.isBlockRight == true)
//                {
//                    if(playerMove2.isRight2 == true)
//                    {
//                        playerMove.isRight2 = true;
//                    }
//                    else
//                    {
//                        playerMove.isRight2 = false;
//                    }
//                }
//                else
//                {
//                    if (playerMove2.isRight2 == true)
//                    {
//                        playerMove.isRight2 = true;
//                    }
//                    else
//                    {
//                        playerMove.isRight2 = false;
//                    }
//                }
//            }
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();

//            playerMove.isBlockRight = true;

//            if (GoalBlock.level <= playerMove.levelRight)
//            {
//                playerMove.isRight2 = true;
//                GoalBlock.isRight = true;
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        //playerMove.isRight = true;

//        if (other.tag == "Player")
//        {
//            playerMove.isRight2 = false;
//            playerMove.levelLeft = 1;
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();
//            GoalBlock.isRight = false;
//            playerMove.isRight2 = false;
//            playerMove.isBlockRight = false;
//        }

//        if (other.tag == "Player")
//        {
//            playerCollider.nextPlayerMove.Remove(PlayerCollider.NextDirection.Right);
//        }
//    }
//}
