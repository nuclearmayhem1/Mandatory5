using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMiniGameController : MonoBehaviour
{
    public GameObject rock, lastPlatform;
    public static SecondMiniGameController sMGC;

    private void Awake() 
    {
        sMGC = this;
    }
}
