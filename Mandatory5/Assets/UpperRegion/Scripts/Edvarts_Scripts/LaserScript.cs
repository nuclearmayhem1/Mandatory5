using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [Header("References")]
    public Renderer energyBall;
    public GameObject laserStart;
    public GameObject hitParticle;

    private LineRenderer laser;
    private Mirror mirrorScript;
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
            laserStart.SetActive(true);
            energyBall.material.EnableKeyword("_EMISSION");
            laser.SetPosition(0, laserStart.transform.position);
            RaycastHit hit;
            if(Physics.Raycast(laserStart.transform.position, laserStart.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    laser.SetPosition(1, hit.point);
                    if(hit.collider.gameObject.tag == "Mirror")
                    {
                        mirrorScript = hit.collider.GetComponentInParent<Mirror>();
                        mirrorScript.ReflectLaser(true, transform, hit.point);
                        hitParticle.SetActive(false);
                    }
                    else
                    {
                        if (mirrorScript != null)
                        {
                            mirrorScript.ReflectLaser(false, null, Vector3.zero);
                        }
                        hitParticle.SetActive(true);
                        hitParticle.transform.position = hit.point + hitParticle.transform.up * 0.1f;
                    }
                }
            }
            else
            {
                laser.SetPosition(1, laserStart.transform.forward * 5000);
                hitParticle.SetActive(false);
                if(mirrorScript != null)
                {
                    mirrorScript.ReflectLaser(false, null, Vector3.zero);
                }

                
            }
        }
        else
        {
            laserStart.SetActive(false);
            energyBall.material.DisableKeyword("_EMISSION");
        }
    }

    public void LaserActive(bool state)
    {
        laserActive = state;
    }
}
