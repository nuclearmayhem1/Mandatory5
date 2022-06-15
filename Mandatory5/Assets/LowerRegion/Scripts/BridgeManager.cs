using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    //this script contains 2 arrays of bridges one array of gameobjects is active when the player is in a spore zone
    //and the other is active when the player isn't in a spore zone.
    public GameObject[] sporeBridge;
    public GameObject[] normBridge;

    void Update()
    {
        if (PlayerDrugChecker.isHigh == true)
        {
            for (int i = 0; i < sporeBridge.Length; i++)
            {
                sporeBridge[i].SetActive(true);
            }
            for (int i = 0; i < normBridge.Length; i++)
            {
                normBridge[i].SetActive(false);
            }
        }
        else if (PlayerDrugChecker.isHigh == false)
        {
            for (int i = 0; i < sporeBridge.Length; i++)
            {
                sporeBridge[i].SetActive(false);
            }
            for (int i = 0; i < normBridge.Length; i++)
            {
                normBridge[i].SetActive(true);
            }
        }
    }
}
