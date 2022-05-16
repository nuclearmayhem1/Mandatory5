using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        string playerLocation = PlayerPrefs.GetString("plLoc", "OverWorld");
        SceneManager.LoadScene(playerLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
