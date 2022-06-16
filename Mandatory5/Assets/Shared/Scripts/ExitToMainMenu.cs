using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{

    private bool exitToMain;
    public GameObject exitToMainMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        exitToMainMenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && exitToMain == false) // Opens the UI panel asking if you want to go back to the main menu.
        {
            exitToMain = true;
            exitToMainMenuCanvas.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && exitToMain == true) // If escape is pressed again when the exit UI panel is open, exit to main menu.
        {
            exitToMain = false;
            exitToMainMenuCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyUp(KeyCode.Return) && exitToMain == true) // If return is pressed while exit UI panel is open, close UI panel and reset.
        {
            exitToMain = false;
            exitToMainMenuCanvas.SetActive(false);
        }
    }
}
