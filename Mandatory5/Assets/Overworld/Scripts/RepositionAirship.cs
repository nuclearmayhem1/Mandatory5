using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionAirship : MonoBehaviour
{

    public Transform airship, Lower_Region_Platform, Middle_Region_Platform, Upper_Region_Platform;
    private int location;

    // Start is called before the first frame update
    void Start()
    {
        // This script moves the airship to be next to whatever Overworld landing tower the player used to get to the region scene they are now coming back from.
        // It preserves immersion by remembering previous actions.
        location = PlayerPrefs.GetInt("lastActiveRegion", 1);

        if (location == 2)
        {
            airship.position = Lower_Region_Platform.position + new Vector3(50f, 50f, 0f);
        }
        else if (location == 3)
        {
            airship.position = Middle_Region_Platform.position + new Vector3(50f, 50f, 0f);
        }
        else if (location == 4)
        {
            airship.position = Upper_Region_Platform.position + new Vector3(50f, 50f, 0f);
        }
    }
}
