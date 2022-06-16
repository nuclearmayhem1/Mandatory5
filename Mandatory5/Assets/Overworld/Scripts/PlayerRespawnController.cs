using UnityEngine;

//Made by: Stig Andr� R�yland.
public class PlayerRespawnController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private GameObject playerStartPoint;
    [SerializeField] private bool colHit = false;
    [SerializeField] private int playerPos = -15;

    private void Start()
    {
        /*This makes sure that if the player has finished an area or deleted their save file, 
         * that they don't spawn inn on a location that was previously visited.
         It also makes sure that the player starts on a selected checkpoint when starting up a world.*/
        if (PlayerPrefs.GetString("CheckPoint", "CheckPoint01") == "CheckPoint01")
        {
            player.transform.position = playerStartPoint.transform.position;
        } else
        /*This makes sure that if the Key "CheckPoint" in player preffs is not the default value of null,
        that it takes the Checkpoint name of the last visited checkpoint and repositions the player to the an object with the same names transform.*/
        {
            Vector3 playerRespawn = GameObject.Find(PlayerPrefs.GetString("CheckPoint", "CheckPoint01")).transform.position;
            player.transform.position = playerRespawn;
        }
    }

    private void Update()
    {
        //this Sets a Vector3's new value to be the previously used checkpoint.
        Vector3 playerRespawn = GameObject.Find(PlayerPrefs.GetString("CheckPoint", "CheckPoint01")).transform.position;

        /*This part of the code respawns the player at the last visited checkpoint if the player either hits a deathplane or a set Y-value. 
         * Can be changed later to include other ways of dying.*/
        if (player.transform.position.y <= playerPos || colHit == true)
        {
            player.transform.position = playerRespawn;
            colHit = false;
        }
    }

    //This part of the code is just to see if the player has entered a DeathPlane.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colHit = true;
        }
    }
}
