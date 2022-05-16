using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitAirship : MonoBehaviour
{

    private bool inAirship = false;
    [SerializeField] private KeyCode exitKey = KeyCode.Escape;
    [SerializeField] GameObject airship, character;

    private void Update()
    {
        if (Input.GetKeyDown(exitKey))
        {
            exitAirship();
        }
    }

    public void exitAirship()
    {
        airship.SetActive(false);
        character.SetActive(true);
    }

    public void enterAirship()
    {
        airship.SetActive(true);
        character.SetActive(false);
    }

}
