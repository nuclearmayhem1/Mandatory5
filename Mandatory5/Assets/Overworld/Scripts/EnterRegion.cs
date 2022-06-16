using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterRegion : MonoBehaviour
{
    public enum regionName
    {
        Lower_Region = 2,
        Middle_Region = 3,
        Upper_Region = 4
    }

    public regionName connectedRegion = regionName.Lower_Region;
        
    public Transform airship;
    public float interactRange = 30f;
    public GameObject landingText;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the child UI text to reflect which region this Overworld landing tower is connected to.
        landingText.transform.GetChild(0).GetComponent<Text>().text = "Press F to enter " + connectedRegion.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // This script is responsible for moving the player from the Overworld scene to one of the region scenes.
        // The player just needs to get close enough to the landing tower in their airship and press F.
        if (airship && Vector3.Distance(airship.position, transform.position) < interactRange)
        {
            landingText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                PlayerPrefs.SetInt("plLoc", (int)connectedRegion);
                PlayerPrefs.SetInt("lastActiveRegion", (int)connectedRegion);
                SceneManager.LoadScene(((int)connectedRegion), LoadSceneMode.Single);
            }
        }
        else
        {
            landingText.SetActive(false);
        }
    }
}
