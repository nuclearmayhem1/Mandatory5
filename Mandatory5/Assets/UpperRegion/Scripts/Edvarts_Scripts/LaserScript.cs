using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [Header("References")]
    public Renderer energyBall;
    public GameObject laserStart;

    private LineRenderer laser;
    private bool laserActive;

    private void Start()
    {
        laser = laserStart.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (laserActive)
        {
            Debug.Log("Active");
            energyBall.material.EnableKeyword("_EMISSION");
            laser.SetPosition(0, laserStart.transform.position);
            RaycastHit hit;
            if(Physics.Raycast(laserStart.transform.position, laserStart.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    laser.SetPosition(1, hit.point);
                }
            }
            else
            {
                laser.SetPosition(1, laserStart.transform.forward * 5000);
            }
        }
        else
        {
            Debug.Log("Not Active");
            energyBall.material.DisableKeyword("_EMISSION");
        }
    }

    public void LaserActive(bool state)
    {
        laserActive = state;
    }
}
