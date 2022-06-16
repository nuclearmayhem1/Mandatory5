using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField]
    GameObject padPuzzle;

    public GameObject ZonePuzzle;
    public GameObject ShroomEnding;
    bool isActive = false;
    public float timer;

    void OnTriggerEnter(Collider col)
    {
        if (!isActive)
        {
            isActive = true;
            Debug.Log("Pad is Activated");
            StartCoroutine("PadOff");
            ShroomEnding.SetActive(true);
        }  

    }
    IEnumerator PadOff()
    {
        yield return new WaitForSeconds(timer);
        ZonePuzzle.SetActive(false);
    }
}
