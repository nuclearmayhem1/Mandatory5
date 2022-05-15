using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public RotatePillar rotatePillar;
    public Canvas pressE;

    private bool canRotate;
    private PuzzleManager manager;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !manager.puzzleDone)
        {
            EnableE(true);
            canRotate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !manager.puzzleDone)
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
