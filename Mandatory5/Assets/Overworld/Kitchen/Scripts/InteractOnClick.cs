using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractOnClick : MonoBehaviour
{
    [SerializeField] private UnityEvent runOnClick;

    public void Clicked()
    {
        runOnClick.Invoke();
    }

}
