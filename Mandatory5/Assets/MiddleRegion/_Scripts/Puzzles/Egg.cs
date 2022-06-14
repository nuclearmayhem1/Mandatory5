using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    public List<Vector3> positions; //Where the egg can be
    public int posNumber; //The numbers that correspond to positions

    void Start()
    {

        posNumber = Random.Range(0, 3); //Puts the egg under one of the three cups

        gameObject.transform.position = positions[posNumber]; //Moves the egg

    }
}
