//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PlayerSpawn : MonoBehaviour
{

    public int playerLocation;

    public void SpawnAtLastCheckpoint()
    {
        // If the player was last in a region when the game closed, start them in that region.
        playerLocation = PlayerPrefs.GetInt("plLoc", 1);
        SceneManager.LoadScene(playerLocation, LoadSceneMode.Single);
    }

    public void SpawnInScene(int sceneNum)
    {
        // This function is used by the fast travel buttons in the Main Menu scene.
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
    }

    public void ClearAllPlayerPrefs()
    {
        // Clears all playerprefs and quits the application so everything resets.
        PlayerPrefs.DeleteAll();
        ExitGame();
    }

    public void ExitGame()
    {
        // Can detect whether it is running as an application or in the unity editor, and run the appropriate code.
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
