using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;


public class RotatePillar : MonoBehaviour
{
    [Header("Paramaters")]
    public float rotationSpeed = 10;

    [Header("References")]
    public CinemachineVirtualCamera pillarCam;
    public Canvas rotateCanvas;

    private bool isActive;
    private PlayerInput playerInput;
    private PillarTrigger trigger;

    private void Start()
    {
        rotateCanvas.enabled = false;
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        trigger = GetComponentInChildren<PillarTrigger>();
    }

    void Update()
    {
        if (isActive)
        {
            rotateCanvas.enabled = true;
            playerInput.enabled = false;
            pillarCam.m_Priority = 11;

            //Rotation
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                trigger.EnableE(true);
                IsActive(false);
            }
        }
        else
        {
            playerInput.enabled = true;
            pillarCam.m_Priority = 9;
            rotateCanvas.enabled = false;
        }
    }

    public void IsActive(bool state) { isActive = state; }

}
