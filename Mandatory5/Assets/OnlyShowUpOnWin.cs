using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyShowUpOnWin : MonoBehaviour
{
    public void TurnOn()
    {

        GetComponent<SpriteRenderer>().enabled = true;



    }
}
