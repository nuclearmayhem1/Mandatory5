using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrugChecker : MonoBehaviour
{
    public static PlayerDrugChecker Instance;

    public static bool isHigh = false;

    void Update()
    {
        if(isHigh == true)  //Very simple and accessible bool for other scripts to check and use to manipulate environments.
        {
            Debug.Log("Currently tripping.");
        }
        else { Debug.Log("Not tripping."); }
    }
}
