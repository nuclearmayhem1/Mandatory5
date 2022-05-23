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
    private GameObject pl;
    public GameObject plPrefab;
    public GameObject exitText;

    private Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        landingTime = clipInfos[0].clip.length;

        mainCamera = Camera.main.transform;
        mainCamera.parent = transform;
        mainCamera.localPosition = new Vector3(0f, 3f, 10f);
        mainCamera.localRotation = new Quaternion(0f, 1f, 0f, 0f);
        
        Invoke("PlayerSpawn", landingTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (pl != null && Vector3.Distance(transform.position, pl.transform.position) < 2f)
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

        if (pl == null)
        {
            mainCamera.LookAt(shipAnimator.transform);
        }
    }

    private void PlayerSpawn()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        if (pl == null)
        {
            pl = GameObject.Instantiate(plPrefab, transform.position + transform.forward * 3f, Quaternion.identity);
        }
        else
        {
            pl.transform.localPosition = transform.forward * 3f;
        }
        pl.transform.rotation = transform.root.rotation;
        mainCamera.parent = pl.transform;
        mainCamera.localPosition = new Vector3(0f, 3f, 5f);
        mainCamera.LookAt(pl.transform);
    }

    private void LeaveRegion()
    {
        mainCamera.parent = transform;
        mainCamera.localPosition = new Vector3(0f, 3f, 10f);
        mainCamera.localRotation = new Quaternion(0f, 1f, 0f, 0f);
        
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
