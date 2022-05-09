using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Header("References")]
    public GameObject laserStart;
    public GameObject hitParticle;
    public Material glowMat, mirrorMat;
    public Renderer mirrorRenderer;

    private LineRenderer laser;
    private Transform incomingLaser;
    private Vector3 mirrorHitLocation;
    private bool reflecting;

    private void Start()
    {
        laser = laserStart.GetComponent<LineRenderer>();
        laserStart.SetActive(false);
    }
    private void Update()
    {
        if (reflecting)
        {
            mirrorRenderer.material = glowMat;
            laserStart.transform.localEulerAngles = new Vector3(90, Vector3.Angle(-transform.forward, incomingLaser.forward), 0);
            laserStart.SetActive(true);
            laser.SetPosition(0, mirrorHitLocation);
            RaycastHit hit;
            if (Physics.Raycast(laserStart.transform.position, laserStart.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    hitParticle.SetActive(true);
                    hitParticle.transform.position = hit.point + hitParticle.transform.up * 0.1f;
                    laser.SetPosition(1, hit.point);
                    if (hit.collider.gameObject.tag == "Mirror")
                    {
                        //Vector3.Angle(transform.forward, incomingLaser.position);
                    }
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
            laserStart.SetActive(false);
            mirrorRenderer.material = mirrorMat;
        }
    }
    public void ReflectLaser(bool state, Transform pillar, Vector3 point)
    {
        reflecting = state;
        incomingLaser = pillar;
        mirrorHitLocation = point;
    }
}
