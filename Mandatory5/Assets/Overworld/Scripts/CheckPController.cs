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
        string checkopintCheck = gameObject.name;
        if (other.CompareTag("Player"))
        {
            //playerStartPoint = gameObject.transform.position;
            PlayerPrefs.SetString("CheckPoint", checkopintCheck);
        }
    }
}