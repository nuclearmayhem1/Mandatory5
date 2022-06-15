using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShroomQuestCompletion : MonoBehaviour
{
    public static bool shroomQuestObjectiveComplete = false;
    private void OnTriggerEnter(Collider other)         //Flips a bool letting ShroomQuest.cs know the objective is complete, then destroys itself.
    {
        if (other.CompareTag("Player"))
        {
            shroomQuestObjectiveComplete = true;
            Destroy(gameObject,0.5f);
            PlayerPrefs.SetInt("Mushroom", 1);
        }
    }
}
