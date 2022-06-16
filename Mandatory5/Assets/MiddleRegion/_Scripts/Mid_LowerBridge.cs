using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_LowerBridge : MonoBehaviour
{
    private Animator bridgeAnim;
    private bool playerHasEntered;



    // Start is called before the first frame update
    void Start()
    {
        playerHasEntered = false;
        bridgeAnim = GameObject.Find("Bridge").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerHasEntered == false)
        {
            if (other.gameObject.CompareTag("Player"))                      //When player touches collider, the bridge animation gets activated.
            {
                bridgeAnim.SetBool("BridgeActivated", true);
                playerHasEntered = true;                                // Bool is set to true, so that if statement doesn't run again
                                                                        // and the animation doesn't play more than once.
            }
        }
        
    }

}
