using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipUpgrades : MonoBehaviour
{
    private static bool firstPart, secondPart;

    [SerializeField] private GameObject baloon1, baloon2, baloon3;

    private void OnEnable()
    {
        if (secondPart)
        {
            baloon3.SetActive(true);
            baloon2.SetActive(false);
            baloon1.SetActive(false);
        }
        else if (firstPart)
        {
            baloon3.SetActive(false);
            baloon2.SetActive(true);
            baloon1.SetActive(false);
        }
        else
        {
            baloon3.SetActive(false);
            baloon2.SetActive(false);
            baloon1.SetActive(true);
        }
    }

    public static void CollectShipPart(shipParts part)
    {
        switch (part)
        {
            case shipParts.first:
                firstPart = true;
                break;
            case shipParts.second:
                secondPart = true;
                break;
            default:
                break;
        }
    }
}

public enum shipParts
{
    first,
    second,
}