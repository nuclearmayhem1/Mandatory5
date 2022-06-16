using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingPlatform : MonoBehaviour
{

    private bool plActive;
    [SerializeField] private Animator shipAnimator;
    private AnimatorClipInfo[] clipInfos;
    private float landingTime, takeOffTime;
    public GameObject playerGeometry;
    public GameObject plPrefab;
    public GameObject exitText;

    private Transform landingCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the animation of the airship coming in to land.
        // Invokes "PlayerSpawn" when the animation ends.
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        landingTime = clipInfos[0].clip.length;

        landingCamera = transform.parent.Find("Landing Platform Camera");

        playerGeometry.transform.parent.gameObject.SetActive(false);
        Invoke("PlayerSpawn", landingTime);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is close to the landing tower door and presses F, Invoke "LeaveRegion".
        if (plActive == true && playerGeometry != null && Vector3.Distance(transform.position, playerGeometry.transform.position) < 3f)
        {
            exitText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                plActive = false;
                LeaveRegion();
            }
        }
        else
        {
            exitText.SetActive(false);
        }
        
        // If the entry or exit animation is playing, the landing towers own camera will be active and should be pointing at the airship.
        if (landingCamera.gameObject.activeSelf)
        {
            landingCamera.LookAt(shipAnimator.transform);
        }
    }

    private void PlayerSpawn()
    {
        // Activates the player and deactives the landing tower camera, so the third person camera is active instead.
        plActive = true;
        landingCamera.gameObject.SetActive(false);
        playerGeometry.transform.parent.gameObject.SetActive(true);
    }

    private void LeaveRegion()
    {
        // Deactivates the player, reactives the landing tower camera, and starts the airship take-off animation.
        playerGeometry.transform.parent.gameObject.SetActive(false);
        landingCamera.gameObject.SetActive(true);
        
        shipAnimator.SetBool("LeaveRegion", true);
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        takeOffTime = clipInfos[0].clip.length;
        // Leave the scene when the take-off animation ends.
        Invoke("ChangeScene", takeOffTime);
    }

    private void ChangeScene()
    {
        PlayerPrefs.SetInt("plLoc", 1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
