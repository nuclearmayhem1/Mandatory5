using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Mid_ChooseAnimalToSendOver : MonoBehaviour
{
    public Mid_Shore midShoreScript;
    public Mid_Boat midBoat;
    private GameObject player;

    private void Start()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OpenCanvas()
    {
        player = GameObject.FindWithTag("Player");
        
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 0;
    }
    public void CloseCanvas()
    {
        
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    public void ChooseAnimal1()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
        player.GetComponent<ThirdPersonController>().LockCameraPosition = false;
        midShoreScript.chosenAnimal = 0;
        midBoat.seatOneFilled = false;
        CloseCanvas();
    }
    public void ChooseAnimal2()
    {
        
        midShoreScript.chosenAnimal = 1;
        CloseCanvas();
    }
}
