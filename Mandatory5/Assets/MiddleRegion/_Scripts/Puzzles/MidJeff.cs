using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidJeff : MonoBehaviour
{
    public bool bedge; //A bool that can be triggered at the end of the moving cups animation, to make it stop animating


    public bool correct = false;

    private void Start()
    {
        GetComponent<Animator>().SetBool("Move", false); //Makes the cup stop moving
    }
}
