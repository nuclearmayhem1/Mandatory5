using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidSwitchScene : MonoBehaviour
{
    public void LoadPuzzle1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadPuzzle2()
    {
        //SceneManager.LoadScene(2);
    }
    public void LoadPuzzle3()
    {
        SceneManager.LoadScene(3);
    }

    public void activateCharacter1()
    {
        RiddleManager.Instance.SpawnCharacter(1);
        
    }

}
