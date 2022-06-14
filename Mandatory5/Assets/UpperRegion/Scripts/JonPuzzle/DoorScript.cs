using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int numberOfRequiredKeys = 2;

    private int numberOfKeysHeld = 0;

    public Animator doorAnim;

    public void AddKey()
    {
        numberOfKeysHeld++;
        if (numberOfKeysHeld == numberOfRequiredKeys)
        {
            Solved();
        }
    }
    private void Solved()
    {
        doorAnim.SetTrigger("Open");
    }
}