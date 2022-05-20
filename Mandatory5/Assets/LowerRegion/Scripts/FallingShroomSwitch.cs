using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingShroomSwitch : MonoBehaviour
{
    public GameObject[] leftPlatforms, rightPlatforms;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < leftPlatforms.Length; i++)
            {
                leftPlatforms[i].SetActive(!leftPlatforms[i].activeSelf);
            }
            for (int i = 0; i < rightPlatforms.Length; i++)
            {
                rightPlatforms[i].SetActive(!rightPlatforms[i].activeSelf);
            }
        }
    }
}
