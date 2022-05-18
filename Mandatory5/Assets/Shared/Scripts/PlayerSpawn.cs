using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int playerLocation = PlayerPrefs.GetInt("plLoc", 1);
        SceneManager.LoadScene(playerLocation, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
