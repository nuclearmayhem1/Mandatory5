using UnityEngine;

public class Pedestal : MonoBehaviour
{
    public DoorScript door;
    public Material solvedMat;

    private bool isUsed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Key" && !isUsed)
        {
            door.AddKey();
            other.gameObject.SetActive(false);
            GetComponent<Renderer>().material = solvedMat;
            isUsed = true;

        }
    }
}