using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public RotatePillar rotatePillar;
    public Canvas pressE;

    private bool canRotate;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EnableE(true);
            canRotate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnableE(false);
            canRotate = false;
        }
    }
    private void Update()
    {
        if (canRotate)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                rotatePillar.IsActive(true);
                EnableE(false);
            }
        }
    }
    public void EnableE(bool state)
    {
        pressE.enabled = state;
    }

}
