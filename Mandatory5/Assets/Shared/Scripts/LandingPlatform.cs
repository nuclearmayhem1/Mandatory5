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
    private GameObject pl, plModel;
    public GameObject plPrefab;
    public GameObject exitText;

    private Transform landingCamera;

    // Start is called before the first frame update
    void Start()
    {
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        landingTime = clipInfos[0].clip.length;

        landingCamera = transform.parent.Find("Landing Platform Camera");
        /*mainCamera.parent = transform;
        mainCamera.localPosition = new Vector3(0f, 3f, 10f);
        mainCamera.localRotation = new Quaternion(0f, 1f, 0f, 0f);*/
        
        Invoke("PlayerSpawn", landingTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (pl != null && Vector3.Distance(transform.position, plModel.transform.position) < 3f)
        {
            exitText.SetActive(true);
            if (plActive == false && Input.GetKeyDown(KeyCode.F))
            {
                plActive = true;
                LeaveRegion();
            }
        }
        else
        {
            exitText.SetActive(false);
        }
        
        if (landingCamera.gameObject.activeSelf)
        {
            landingCamera.LookAt(shipAnimator.transform);
        }

    }

    private void PlayerSpawn()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        if (pl == null)
        {
            pl = GameObject.Instantiate(plPrefab, transform.position + transform.forward * 3.5f, Quaternion.identity);
        }
        else
        {
            pl.transform.localPosition = transform.forward * 3f;
        }
        plModel = pl.transform.Find("PlayerArmature").gameObject;
        pl.transform.rotation = transform.root.rotation;
        /*mainCamera.parent = pl.transform;
        mainCamera.localPosition = new Vector3(0f, 3f, 5f);
        mainCamera.LookAt(pl.transform);*/
        landingCamera.gameObject.SetActive(false);
        //exitText.transform.parent.GetComponent<Canvas>().worldCamera = pl.transform.Find("MainCamera").GetComponent<Camera>();
    }

    private void LeaveRegion()
    {
        /*mainCamera.parent = transform;
        mainCamera.localPosition = new Vector3(0f, 3f, 10f);
        mainCamera.localRotation = new Quaternion(0f, 1f, 0f, 0f);*/
        landingCamera.gameObject.SetActive(true);
        
        Destroy(pl);
        shipAnimator.SetBool("LeaveRegion", true);
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        takeOffTime = clipInfos[0].clip.length;
        Invoke("ChangeScene", takeOffTime);
    }

    private void ChangeScene()
    {
        PlayerPrefs.SetInt("plLoc", 1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
