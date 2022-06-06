using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidJeff : MonoBehaviour
{
    public bool bedge;


    public bool correct = false;

    private void Start()
    {
        GetComponent<Animator>().SetBool("Move", false);
    }
}
