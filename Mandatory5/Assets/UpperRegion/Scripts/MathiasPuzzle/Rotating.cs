using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public static Rotating rotation;

    public float rotationSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        rotation = this;
    }
    void Start()
    {
        SetRotationSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    public void SetRotationSpeed()
    {
        rotationSpeed = 45f;
    }
}
