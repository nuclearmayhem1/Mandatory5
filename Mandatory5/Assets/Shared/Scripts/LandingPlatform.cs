using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPlatform : MonoBehaviour
{

    public string sceneName = "OverWorld";
    private bool plActive;
    [SerializeField] private Animator shipAnimator;
    private AnimatorClipInfo[] clipInfos;
    private float landingTime, takeOffTime;
    private GameObject pl;
    public GameObject plPrefab;
    public GameObject exitText;

    // Start is called before the first frame update
    void Start()
    {
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        landingTime = clipInfos[0].clip.length;
        
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
        PlayerPrefs.SetString("plLoc", sceneName);
    }

    private void LeaveRegion()
    {
        Destroy(pl);
        shipAnimator.SetBool("LeaveRegion", true);
        clipInfos = shipAnimator.GetCurrentAnimatorClipInfo(0);
        takeOffTime = clipInfos[0].clip.length;
    }
}
