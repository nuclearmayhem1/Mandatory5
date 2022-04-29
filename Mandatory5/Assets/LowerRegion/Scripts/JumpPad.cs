using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    Material selfMaterial;
    Color originalColor;
    bool inSporeZone = false, jumpCountdown = false;
    public float bounceHeight = 10;
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        selfMaterial = GetComponent<MeshRenderer>().material;
        originalColor = selfMaterial.color;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("SporeZone"))
        {
            inSporeZone = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(inSporeZone == true)
            {
                jumpCountdown = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SporeZone"))
        {
            inSporeZone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inSporeZone == true)
        {
            selfMaterial.SetColor("_Color", Color.green);
        }
        else
        {
            selfMaterial.color = originalColor;
        }

        if(jumpCountdown == true)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().Move(Vector3.up * Time.deltaTime * bounceHeight);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().Move(Vector3.forward * Time.deltaTime * bounceHeight * 0.05f);
            speed -= Time.deltaTime;
            if(speed <= 0)
            {
                jumpCountdown = false;
                speed = 2f;
            }
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().isGrounded == true)
            {
                jumpCountdown = false;
                speed = 2f;
            }
        }
    }
}
