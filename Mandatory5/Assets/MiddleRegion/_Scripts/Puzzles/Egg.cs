using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{


    public List<Vector3> positions;//Where the egg can be
    public int posNumber;//The numbers that correspond to positions


    void Start()
    {

        posNumber = Random.Range(0, 3); //Puts the egg under one of the three cups


        gameObject.transform.localPosition = positions[posNumber]; //Moves the egg
    }
    

        

    public void TeleportToCorrectCup()
    {
        gameObject.transform.localPosition = posNumber switch //Puts the egg under the same cup, at it's new position, essentially faking the process - "magic" ;)
        {
            0 => positions[2],
            1 => positions[1],
            2 => positions[0],
            _ => gameObject.transform.localPosition
        };
    }
}
