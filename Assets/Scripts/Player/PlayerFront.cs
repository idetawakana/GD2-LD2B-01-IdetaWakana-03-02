//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerFront : MonoBehaviour
//{
//    private PlayerMove playerMove;
//    private PlayerMove playerMove2;
//    private PlayerMove playerMove3;

//    private PlayerCollider playerCollider;

//    private
//    GoalBlock;

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
//        //    playerMove.levelBack += playerMove2.levelBack;
//        //}

//        if (other.tag == "Player")
//        {
//            playerMove3 = other.gameObject.GetComponent<PlayerMove>();

//            playerCollider.nextPlayerMove.Add(PlayerCollider.NextDirection.Front, playerMove);
//        }
//    }

//    private void OnTriggerStay(Collider other)
//    {
//        //playerMove.isFront = false;

//        if (other.tag == "Player")
//        {
//            playerMove2 = other.gameObject.GetComponent<PlayerMove>();
//            if (playerMove2.isFront == true)
//            {
//                playerMove.isFront2 = true;
//            }
//            else
//            {
//                if (playerMove2.isBlockFront == true)
//                {
//                    if (playerMove2.isFront2 == true)
//                    {
//                        playerMove.isFront2 = true;
//                    }
//                    else
//                    {
//                        playerMove.isFront2 = false;
//                    }
//                }
//            }
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();

//            playerMove.isBlockFront = true;

//            if (GoalBlock.level <= playerMove.levelFront)
//            {
//                playerMove.isFront2 = true;
//                GoalBlock.isFront = true;
//            }
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        //playerMove.isFront = true;

//        if(other.tag == "Player")
//        {
//            playerMove.isFront2 = false;
//            playerMove.levelBack = 1;
//        }

//        if (other.tag == "GoalBlock")
//        {
//            GoalBlock = other.gameObject.GetComponent<GoalBlock>();
//            GoalBlock.isFront = false;
//            playerMove.isFront2 = false;
//            playerMove.isBlockFront = false;
//        }

//        if (other.tag == "Player")
//        {
//            playerCollider.nextPlayerMove.Remove(PlayerCollider.NextDirection.Front);
//        }
//    }
//}
