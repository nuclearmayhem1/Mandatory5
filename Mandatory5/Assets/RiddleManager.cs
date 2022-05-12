using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class RiddleManager : MonoBehaviour
{
   public static RiddleManager Instance;


   public GameObject[] characters;
   
   private void Awake() => Instance = this;


   public void SpawnCharacter(int chararcterNumber)
   {
      
      characters[chararcterNumber].SetActive(true);
      characters[chararcterNumber-1].SetActive(false);


   }
   
   
}
