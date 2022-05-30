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
        //airship.position = Lower_Region_Platform.position + new Vector3(0f, 100f, 0f);
        location = PlayerPrefs.GetInt("lastActiveRegion", 1);
        //Debug.Log(location);

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
