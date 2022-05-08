using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{

    public GameObject[] sporeBridge;
    public GameObject[] normBridge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
