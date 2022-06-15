using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
  
    public Transform tFT; //teleportFromTOp
    public Transform tTB; //teleportToButtom
  

    // Start is called before the first frame update
    void Start()
    {


        tFT = GameObject.Find("TeleportZoneTop").transform;
        tTB = GameObject.Find("TeleportZoneButton").transform;

      
    }

    private void OnTriggerEnter(Collider hit)
    {
         if (hit.CompareTag("TeleportZoneTop"))
         {

            transform.position = tTB.transform.position;

         }


       

    }



}

