using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{

    public List<Vector3> positions;
    public int posNumber;

    void Start()
    {

        posNumber = Random.Range(0, 3);

        gameObject.transform.position = positions[posNumber];



        


    }
}
