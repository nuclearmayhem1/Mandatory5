using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public FlipFlop onButton;
    public SelectorButton selector;

    private bool isOn = false;
    private int heat = 0;

    public Color off, on1, on2, on3;

    private Material topMat;

    private void Start()
    {
        topMat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<PanAndPot>(out PanAndPot pot))
        {
            if (!isOn)
            {
                pot.heat = 0;
            }
            else
            {
                pot.heat = heat;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PanAndPot>(out PanAndPot pot))
        {
            pot.heat = 0;
        }
    }

    private void Update()
    {
        isOn = onButton.state;
        heat = selector.state;

        if (!isOn)
        {
            topMat.color = off;
        }
        else
        {
            if (heat == 1)
            {
                topMat.color = on1;
            }
            else if (heat == 2)
            {
                topMat.color = on2;
            }
            else if (heat == 3)
            {
                topMat.color = on3;
            }
        }

    }

}
