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
        if (Input.GetKeyUp(KeyCode.Escape) && exitToMain == false)
        {
            exitToMain = true;
            exitToMainMenuCanvas.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && exitToMain == true)
        {
            exitToMain = false;
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyUp(KeyCode.Return) && exitToMain == true)
        {
            exitToMain = false;
            exitToMainMenuCanvas.SetActive(false);
        }
    }
}
