using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirshipController : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float rotationSpeed;
    private float targetRotation;

    [SerializeField] private float throtthleForce;
    [SerializeField] private float throtthleChangeSpeed;
    [SerializeField] [Range(0,-1)] private float maxReverseThrotthle;
    private float throtthle = 0;

    [SerializeField] private Image throtthleBar, reverseBar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Inputs();
        UpdateUI();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Inputs()
    {
        targetRotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            targetRotation = Mathf.Lerp(targetRotation, 0, rotationSmooth);
        }

        if (Input.GetKey(KeyCode.W))
        {
            throtthle += throtthleChangeSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            throtthle -= throtthleChangeSpeed * Time.deltaTime;
        }
        else
        {
            if (throtthle > -0.025f && throtthle < 0.025f)
            {
                throtthle = 0;
            }
        }

        throtthle = Mathf.Clamp(throtthle, maxReverseThrotthle, 1);

    }

    [SerializeField] [Range(0,1)] private float rotationSmooth = 0.9f;
    private float currentRotation = 0;

    private void Movement()
    {
        rb.AddForce(transform.forward * throtthle * throtthleForce);

        currentRotation = transform.rotation.eulerAngles.y + targetRotation;

        transform.localRotation = Quaternion.Euler(0, currentRotation, 0);

    }

    private void UpdateUI()
    {
        if (throtthle == 0)
        {
            throtthleBar.fillAmount = 0;
            reverseBar.fillAmount = 0;
        }
        else if (throtthle > 0)
        {
            reverseBar.fillAmount = 0;
            throtthleBar.fillAmount = throtthle;
        }
        else if (throtthle < 0)
        {
            throtthleBar.fillAmount = 0;
            reverseBar.fillAmount = Mathf.Abs(throtthle);
        }


    }
}
