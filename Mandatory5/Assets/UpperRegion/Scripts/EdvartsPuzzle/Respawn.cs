using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("References")]
    public Transform respawnPoint;

    private PuzzleManager manager;
    private bool respawnDone;
    private bool respawn;

    private void Start()
    {
        manager = FindObjectOfType<PuzzleManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !respawnDone)
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


    private void SetRespawn(bool state)
    {
        respawn = state;
    }
    public void SetRespawnDone(bool state)
    {
        respawnDone = state;
    }
}
