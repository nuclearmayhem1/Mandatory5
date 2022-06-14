using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    public Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        transform.LookAt(mainCamera.transform.position, Vector3.up);
    }
}
