using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Header("References")]
    public GameObject laserStart;
    public GameObject hitParticle;
    public Material glowMat, mirrorMat;
    public Renderer mirrorRenderer;

    public GameObject reference;

    private Mirror mirrorScript;
    private LineRenderer laser;
    private Transform incomingLaser;
    private Vector3 mirrorHitLocation;
    public bool reflecting;

    private void Start()
    {
        laser = laserStart.GetComponent<LineRenderer>();
        laserStart.SetActive(false);
    }
    private void Update()
    {
        
        if (reflecting)
        {
            Debug.Log(Vector3.SignedAngle(transform.forward, -incomingLaser.forward, -laserStart.transform.up));
            laserStart.SetActive(true);
            laserStart.transform.position = mirrorHitLocation + transform.forward * 0.1f;
            laserStart.transform.localEulerAngles = new Vector3(0, Vector3.SignedAngle(transform.forward, -incomingLaser.forward, -laserStart.transform.up), 0);
            laser.SetPosition(0, laserStart.transform.position);
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
                        hitParticle.SetActive(false);
                        if (!mirrorScript.reflecting)
                        {
                            mirrorScript.ReflectLaser(true, transform, hit.point);
                        }

                    }
                    else
                    {
                        if (mirrorScript != null)
                        {
                            mirrorScript.ReflectLaser(false, null, Vector3.zero);
                            mirrorScript = null;
                        }
                        hitParticle.SetActive(true);
                        hitParticle.transform.position = hit.point + hitParticle.transform.up * -0.1f;
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
            if (mirrorScript != null)
            {
                mirrorScript.ReflectLaser(false, null, Vector3.zero);
            }
        }
    }
    public void ReflectLaser(bool state, Transform pillar, Vector3 point)
    {
        reflecting = state;
        incomingLaser = pillar;
        mirrorHitLocation = point;
    }
}
