using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShroom : MonoBehaviour
{
    public GameObject sporeZone;
    public GameObject sporeAura;
    private bool isBlue = true;

    private void Update()
    {
        if (PlayerDrugChecker.isHigh == true)
        {
            SetAuraColor("yellow");
        }
        else
        {
            SetAuraColor("blue");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sporeZone.SetActive(!sporeZone.activeSelf);
            if (!sporeZone.activeSelf)
            {
                PlayerDrugChecker.isHigh = false;
            }

            GetComponent<ParticleSystem>().Play();
        }
    }

    private void SetAuraColor( string color)
    {
        if (color == "blue")
        {
            sporeAura.GetComponent<Renderer>().material.color = new Color(0.15f, 0.18f, 0.70f);
            isBlue = true;
        }
        else if (color == "yellow")
        {
            sporeAura.GetComponent<Renderer>().material.color = new Color(0.85f, 0.85f, 0.27f);
            isBlue = false;
        }
    }

}