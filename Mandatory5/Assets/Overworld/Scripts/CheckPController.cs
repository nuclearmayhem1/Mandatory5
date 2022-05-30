using UnityEngine;

//Made by: Stig André Røyland
public class CheckPController : MonoBehaviour
{
    //Vector3 playerStartPoint;
    

    private void Start()
    {
        /*string checkpoint = PlayerPrefs.GetString("CheckPoint", null);
        if (checkpoint != PlayerPrefs.GetString("CheckPoint", null) || PlayerPrefs.HasKey("CheckPoint") != true)
        {
            
        }*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        string compare = PlayerPrefs.GetString("CheckPoint", null);
        string checkpointCheck = gameObject.name;
        if (other.CompareTag("Player") && checkpointCheck != compare)
        {
            //playerStartPoint = gameObject.transform.position;
            PlayerPrefs.SetString("CheckPoint", checkpointCheck);
        }
    }
}