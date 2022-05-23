//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class PlayerSpawn : MonoBehaviour
{

    public int playerLocation;

    public void SpawnAtLastCheckpoint()
    {
        playerLocation = PlayerPrefs.GetInt("plLoc", 1);
        SceneManager.LoadScene(playerLocation, LoadSceneMode.Single);
    }

    public void SpawnInScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
        //EditorApplication.ExitPlaymode();
    }
}
