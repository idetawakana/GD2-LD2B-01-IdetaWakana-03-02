using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBack2 : MonoBehaviour
{
    private PlayerMove2 playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = transform.parent.gameObject.GetComponent<PlayerMove2>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        playerMove.isBack = false;
    }

    private void OnTriggerExit(Collider other)
    {
        playerMove.isBack = true;
    }
}
