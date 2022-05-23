using UnityEngine;

public class Mirror : MonoBehaviour
{
    [Header("References")]
    public GameObject laserStart;
    public GameObject hitParticle;
    public Material glowMat, mirrorMat;
    public Renderer mirrorRenderer;
    [HideInInspector] public bool reflecting;

    private Mirror mirrorScript;
    private LineRenderer laser;
    private float hitAngle;
    private Vector3 mirrorHitLocation;
    private bool canReflect;


    private void Start()
    {
        laser = laserStart.GetComponent<LineRenderer>();
        laserStart.SetActive(false);
    }
    private void Update()
    {
        if (reflecting)
        {
            laserStart.SetActive(true);
            laserStart.transform.position = mirrorHitLocation + transform.forward * 0.1f;
            laserStart.transform.localEulerAngles = new Vector3(0, hitAngle, 0);
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
                            canReflect = true;
                        }
                        if (canReflect)
                        {
                            mirrorScript.ReflectLaser(true, Vector3.SignedAngle(hit.normal, -laserStart.transform.forward, -transform.up), hit.point);
                        }

                    }
                    else if(hit.collider.gameObject.tag == "Brazier")
                    {
                        hit.collider.GetComponentInParent<Brazier>().BrazierHit();
                        hitParticle.SetActive(false);
                    }
                    else
                    {
                        if (mirrorScript != null)
                        {
                            mirrorScript.ReflectLaser(false, 0, Vector3.zero);
                            mirrorScript = null;
                            canReflect = false;
                        }
                        hitParticle.SetActive(true);
                        hitParticle.transform.position = hit.point + hitParticle.transform.up * -0.1f;
                    }
                }
            }
            else
            {
                if (mirrorScript != null)
                {
                    mirrorScript.ReflectLaser(false, 0, Vector3.zero);
                    mirrorScript = null;
                    canReflect = false;
                }
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
                mirrorScript.ReflectLaser(false, 0, Vector3.zero);
                mirrorScript = null;
                canReflect = false;
            }
        }
    }
    public void ReflectLaser(bool state, float angle, Vector3 point)
    {
        reflecting = state;
        hitAngle = angle;
        mirrorHitLocation = point;
    }
}
