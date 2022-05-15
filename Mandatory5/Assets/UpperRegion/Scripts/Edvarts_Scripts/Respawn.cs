using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;

    private PuzzleManager manager;
    private bool respawn;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!respawn)
            {
                SetRespawn(true);
            }
            else
            {
                other.transform.position = respawnPoint.position;
            }
        }
    }


    public void SetRespawn(bool state)
    {
        respawn = state;
    }
}
