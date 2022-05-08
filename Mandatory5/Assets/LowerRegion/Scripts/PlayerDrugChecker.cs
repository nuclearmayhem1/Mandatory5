using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrugChecker : MonoBehaviour
{
    public static PlayerDrugChecker Instance;

    public static bool isHigh = false;

    void Update()
    {
        if(isHigh == true)
        {
            Debug.Log("Currently tripping.");
        }
        else { Debug.Log("Not tripping."); }
    }
}
