using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Header("References")]
    public GameObject laserStart;
    public GameObject hitParticle;
    public Material glowMat, mirrorMat;
    public Renderer mirrorRenderer;

    private Mirror mirrorScript;
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
            laserStart.transform.localEulerAngles = new Vector3(0, Vector3.SignedAngle(transform.forward, -incomingLaser.forward, -laserStart.transform.up) * 2, 0);
            laserStart.SetActive(true);
            laser.SetPosition(0, mirrorHitLocation);
            mirrorRenderer.material = glowMat;
            RaycastHit hit;
            if (Physics.Raycast(laserStart.transform.position, laserStart.transform.forward, out hit))
            {
                if (hit.collider)
                {
                    hitParticle.SetActive(true);
                    laser.SetPosition(1, hit.point);
                    if (hit.collider.gameObject.tag == "Mirror")
                    {
                        mirrorScript = hit.collider.GetComponentInParent<Mirror>();
                        mirrorScript.ReflectLaser(true, transform, hit.point);
                        hitParticle.SetActive(false);
                    }
                    else
                    {
                        mirrorScript.ReflectLaser(false, null, Vector3.zero);
                        hitParticle.SetActive(true);
                        hitParticle.transform.position = hit.point + hitParticle.transform.up * -0.1f;
                    }
                }
            }
            else
            {
                laser.SetPosition(1, laserStart.transform.forward * 5000);
                hitParticle.SetActive(false);
                mirrorScript.ReflectLaser(false, null, Vector3.zero);
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
