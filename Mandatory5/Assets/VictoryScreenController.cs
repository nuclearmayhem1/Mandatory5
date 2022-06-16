using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreenController : MonoBehaviour
{
    public GameObject child;

    private void Update()
    {
        if (GameObject.Find("Hash(Clone)") != null)
        {
            child.SetActive(true);
        }
    }

}
