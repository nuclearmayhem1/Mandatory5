using StarterAssets;
using UnityEngine;

public class ClawMachineConsole : MonoBehaviour
{
    public bool canPressE;
    public GameObject player;
    public GameObject ClawCanvas;
    public GameObject HECK;

    public void Start()
    {
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
            player.transform.parent.gameObject.SetActive(false);
            HECK.SetActive(true);
            // player.GetComponent<ThirdPersonController>().freezePlayerCamera = true;
            Cursor.lockState = CursorLockMode.None;
            ClawCanvas.GetComponent<CanvasGroup>().alpha = 1;
            ClawCanvas.GetComponent<CanvasGroup>().interactable = true;
            ClawCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            player.transform.parent.gameObject.SetActive(true);
            HECK.SetActive(false);
            player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;
            Cursor.visible = false;
            player.GetComponent<ThirdPersonController>().freezePlayerCamera = false;
            Cursor.lockState = CursorLockMode.Locked;
            ClawCanvas.GetComponent<CanvasGroup>().alpha = 0;
            ClawCanvas.GetComponent<CanvasGroup>().interactable = false;
            ClawCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;

        }

    }
}
