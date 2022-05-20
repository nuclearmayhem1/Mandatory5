using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle1Object : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RiddleManager.Instance.SolvedFirstRiddle();
            gameObject.SetActive(false);
        }
    }
}
