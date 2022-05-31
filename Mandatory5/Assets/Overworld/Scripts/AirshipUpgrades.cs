using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirshipUpgrades : MonoBehaviour
{
    private static bool firstPart, secondPart;

    [SerializeField] private GameObject baloon1, baloon2, baloon3;
    [SerializeField] private GameObject col01, col02;

    private void OnEnable()
    {
        if (GameManager.Instance.GetItemValue("PartOne") == 1)
        {
            firstPart = true;
        }
        else
        {
            firstPart = false;
        }
        if (GameManager.Instance.GetItemValue("PartTwo") == 1)
        {
            secondPart = true;
        }
        else
        {
            secondPart = false;
        }

        if (secondPart)
        {
            baloon3.SetActive(true);
            baloon2.SetActive(false);
            baloon1.SetActive(false);
            col01.SetActive(true);
            col02.SetActive(true);
        }
        else if (firstPart)
        {
            baloon3.SetActive(false);
            baloon2.SetActive(true);
            baloon1.SetActive(false);
            col02.SetActive(false);
            col01.SetActive(true);
        }
        else
        {
            baloon3.SetActive(false);
            baloon2.SetActive(false);
            baloon1.SetActive(true);
            col01.SetActive(false);
            col02.SetActive(false);
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