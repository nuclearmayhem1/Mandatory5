using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnLoad : MonoBehaviour
{

    private void Awake()
    {
        if (GameObject.Find("DontDestroyOnLoad") && GameObject.Find("DontDestroyOnLoad") != this.gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
            
    }

}
