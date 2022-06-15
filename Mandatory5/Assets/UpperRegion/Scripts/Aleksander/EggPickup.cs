using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPickup : MonoBehaviour
{
    public WinMessage winMessage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winMessage.Message("You got an Egg!");
            Destroy(gameObject);
        }
    }
}
