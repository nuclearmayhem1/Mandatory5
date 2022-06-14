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
    private bool camActive;
    private bool camDone;
    public PlayerInput playerInput;
    private PillarTrigger trigger;
    private PuzzleManagerEdvart manager;

    private void Awake()
    {
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        manager = FindObjectOfType<PuzzleManagerEdvart>();
    }

    private void Start()
    {
        rotateCanvas.enabled = false;
        
        trigger = GetComponentInChildren<PillarTrigger>();
        
    }

    void Update()
    {
        if (manager.puzzleDone)
        {
            Done();
        }
        else if (isActive && !manager.puzzleDone)
        {
            if (!camActive)
            {
                rotateCanvas.enabled = true;
                playerInput.enabled = false;
                pillarCam.m_Priority = 11;
                camDone = false;
                camActive = true;
            }
            
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
            Done();
        }
    }

    public void IsActive(bool state) { isActive = state; }

    private void Done()
    {
        if (!camDone)
        {
            playerInput.enabled = true;
            pillarCam.m_Priority = 9;
            rotateCanvas.enabled = false;
            camActive = false;
            camDone = true; 
        }

    }
}
