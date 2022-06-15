using System;
using StarterAssets;
using UnityEngine;

public class ClawMachineConsole : MonoBehaviour
{
    public bool canPressE = false;
    public GameObject player;
    public GameObject ClawCanvas;
    public GameObject HECK;
    private bool playerActive = true;

    public void Start()
    {
        canPressE = false;
        playerActive = true;
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
        }
        ClawCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            canPressE = true;
        }
    }

    void Update()
    {
        if (canPressE && Input.GetKeyUp(KeyCode.E))
        {
            Cursor.visible = true;
            player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
            player.gameObject.SetActive(false);
            HECK.SetActive(true);
            // player.GetComponent<ThirdPersonController>().freezePlayerCamera = true;
            Cursor.lockState = CursorLockMode.None;
            ClawCanvas.GetComponent<CanvasGroup>().alpha = 1;
            ClawCanvas.GetComponent<CanvasGroup>().interactable = true;
            ClawCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
            playerActive = false;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!playerActive)
            {
                
                ResetToPlayer();
                
            }
        }

    }


    public void ResetToPlayer()
    {
        Debug.Log("Trying to return to player");
        player.gameObject.SetActive(true);
        HECK.SetActive(false);
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        Cursor.visible = false;
        player.GetComponent<ThirdPersonController>().freezePlayerCamera = false;
        Cursor.lockState = CursorLockMode.Locked;
        ClawCanvas.GetComponent<CanvasGroup>().alpha = 0;
        ClawCanvas.GetComponent<CanvasGroup>().interactable = false;
        ClawCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        playerActive = true;
    }
}
