using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameRestarter : MonoBehaviour
{
    public RunningShroom[] mushrooms;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.tag == "MController1")
            {
                ColorMiniGameController.cMGC.minigameHasEnded = false;
                ColorMiniGameController.cMGC.readyAgain = true;
            }

            if (gameObject.tag == "MController2")
            {
                RunningShroom.rShroom.RestartPuzzle(mushrooms);
            }
        }
    }
}
