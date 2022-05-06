using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [Header("References")]
    public Renderer energyBall;
    public GameObject laserStart;
    public GameObject hitParticle;

    private LineRenderer laser;
    private bool laserActive;

    private void Start()
    {
        laser = laserStart.GetComponent<LineRenderer>();
        laserStart.SetActive(false);
        hitParticle.SetActive(false);
    }

    private void Update()
    {
        if (laserActive)
        {
            Debug.Log("Active");
            laserStart.SetActive(true);
            energyBall.material.EnableKeyword("_EMISSION");
            laser.SetPosition(0, laserStart.transform.position);
            RaycastHit hit;
            if(Physics.Raycast(laserStart.transform.position, laserStart.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    hitParticle.SetActive(true);
                    hitParticle.transform.position = hit.point+hitParticle.transform.up * 0.1f;
                    laser.SetPosition(1, hit.point);
                }
            }
            else
            {
                laser.SetPosition(1, laserStart.transform.forward * 5000);
                hitParticle.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Not Active");
            laserStart.SetActive(false);
            energyBall.material.DisableKeyword("_EMISSION");
        }
    }

    public void LaserActive(bool state)
    {
        laserActive = state;
    }
}
