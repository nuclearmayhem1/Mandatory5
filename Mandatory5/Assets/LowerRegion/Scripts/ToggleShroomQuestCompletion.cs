using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShroomQuestCompletion : MonoBehaviour
{
    public static bool bogCrossed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bogCrossed = true;
        }
    }
}
