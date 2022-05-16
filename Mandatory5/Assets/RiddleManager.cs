using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
   public static RiddleManager Instance;


   public GameObject[] characters, findableObjects;
   public GameObject riddleHintUI;
   public int currentRiddle = 0;
   private void Awake() => Instance = this;

   public void SpawnCharacter(int chararcterNumber)
   {
      
      characters[chararcterNumber].SetActive(true);
      characters[chararcterNumber-1].SetActive(false);
   }

   public void StartFirstRiddle(string hint)
   {
      riddleHintUI.GetComponent<TMP_Text>().text = "- " + hint;
      riddleHintUI.GetComponent<TMP_Text>().color = new Color(1f, 1f, 1f, 1f);
      findableObjects[0].SetActive(true);

   }
   public void SolvedFirstRiddle()
   {
      riddleHintUI.GetComponent<TMP_Text>().text = "Found it! Bring it back to Diddle";
      riddleHintUI.GetComponent<TMP_Text>().color = Color.green;
      SpawnCharacter(1);
      currentRiddle = 1;
   }   
}
