//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerLeft : MonoBehaviour
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
//        //if(other.tag == "Player")
//        //{
//        //    playerMove2 = other.gameObject.GetComponent<PlayerMove>();
//        //    playerMove.levelRight += playerMove2.levelRight;
//        //}

//        if (other.tag == "Player")
//        {
//            playerMove3 = other.gameObject.GetComponent<PlayerMove>();

//            playerCollider.nextPlayerMove.Add(PlayerCollider.NextDirection.Left, playerMove);
//        }
//    }

//    private void OnTriggerStay(Collider other)
//    {
//        //playerMove.isLeft = false;

//        if (other.tag == "Player")
//        {
//            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
//            if (playerMove2.isLeft == true)
//            {
//                playerMove.isLeft2 = true;
//            }
//            else
//            {
//                if (playerMove2.isBlockLeft == true)
//                {
//                    if (playerMove2.isLeft2 == true)
//                    {
//                        playerMove.isLeft2 = true;
//                    }
//                    else
//                    {
//                        playerMove.isLeft2 = false;
//                    }
//                }
//            }
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();

//            playerMove.isBlockLeft = true;

//            if (GoalBlock.level <= playerMove.levelLeft)
//            {
//                playerMove.isLeft2 = true;
//                GoalBlock.isLeft = true;
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        //playerMove.isLeft = true;
//        if (other.tag == "Player")
//        {
//            playerMove.isLeft2 = false;
//            playerMove.levelRight = 1;
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();
//            GoalBlock.isLeft = false;
//            playerMove.isLeft2 = false;
//            playerMove.isBlockLeft = false;
//        }

//        if (other.tag == "Player")
//        {
//            playerCollider.nextPlayerMove.Remove(PlayerCollider.NextDirection.Left);
//        }
//    }
//}
