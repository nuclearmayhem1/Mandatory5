using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Welder : ManipulatableTool
{
    [SerializeField] private GameObject barrel;
    [SerializeField] LineRenderer laser;
    [SerializeField] private float weldDistance = 5f;
    [SerializeField] private GameObject targetIndicator;
    [SerializeField] private GameObject firstObject;
    [SerializeField] private GameObject carriedObject;
    [SerializeField] private GameObject jointIndicatorPrefab;
    private GameObject spawnedJointIndicator;

    private GameObject weldTarget = null;
    private Vector3 jointPoint = Vector3.zero;

    private int weldMode = 0;
    [SerializeField] private weldModeGraphic[] weldmodeGraphics;

    [SerializeField] Canvas display;
    [SerializeField] Image icon;
    [SerializeField] Text description;

    private Vector3 targetNormal = Vector3.zero;

    private void Update()
    {
        if (held)
        {
            laser.enabled = true;
            display.gameObject.SetActive(true);
            icon.sprite = weldmodeGraphics[weldMode].icon;
            description.text = weldmodeGraphics[weldMode].description;

            Ray laserRay = new Ray(barrel.transform.position, barrel.transform.forward);
            Physics.Raycast(laserRay, out RaycastHit hitInfo, weldDistance);
            if (hitInfo.collider != null)
            {
                laser.SetPosition(0, barrel.transform.position);
                laser.SetPosition(1, hitInfo.point);
                if (hitInfo.collider.transform.root.tag == "Manipulatable")
                {
                    targetIndicator.SetActive(true);
                    if (carriedObject == null)
                    {
                        laser.startColor = Color.green;
                        laser.endColor = Color.green;
                        targetIndicator.transform.position = hitInfo.point;
                        targetIndicator.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
                        weldTarget = hitInfo.collider.transform.root.gameObject;
                        jointPoint = hitInfo.point;
                        targetNormal = hitInfo.normal;
                    }
                    else
                    {
                        laser.startColor = Color.blue;
                        laser.endColor = Color.blue;
                        targetIndicator.transform.position = hitInfo.point;
                        targetIndicator.GetComponent<MeshRenderer>().sharedMaterial.color = Color.blue;
                        weldTarget = hitInfo.collider.transform.gameObject;
                        jointPoint = hitInfo.point;
                        targetNormal = hitInfo.normal;
                    }

                }
                else
                {
                    targetIndicator.SetActive(true);
                    if (carriedObject == null)
                    {
                        laser.startColor = Color.yellow;
                        laser.endColor = Color.yellow;
                        targetIndicator.transform.position = hitInfo.point;
                        targetIndicator.GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
                        weldTarget = null;
                    }
                    else
                    {
                        laser.startColor = Color.yellow;
                        laser.endColor = Color.yellow;
                        targetIndicator.transform.position = hitInfo.point;
                        targetIndicator.GetComponent<MeshRenderer>().sharedMaterial.color = Color.yellow;
                        //jointPoint = hitInfo.point;
                        //weldTarget = hitInfo.collider.transform.gameObject;
                        weldTarget = null;
                    }
                }
            }
            else
            {
                laser.SetPosition(0, barrel.transform.position);
                laser.SetPosition(1, barrel.transform.position + barrel.transform.forward * weldDistance);
                laser.startColor = Color.red;
                laser.endColor = Color.red;
                targetIndicator.SetActive(false);
                weldTarget = null;
            }


        }
        else
        {
            laser.enabled = false;
            if (carriedObject != null)
            {
                Destroy(spawnedJointIndicator);
                spawnedJointIndicator = null;
                carriedObject.transform.parent = null;
                carriedObject.GetComponent<Rigidbody>().isKinematic = false;
                carriedObject = null;
            }
            targetIndicator.SetActive(false);
            display.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            pivot = null;
        }
        Debug.Log(targetNormal);
        Debug.LogWarning(carriedNormals);
    }

    private Vector3 carriedNormals = Vector3.zero;

    public override void UseTool()
    {
        if (carriedObject == null)
        {
            if (weldTarget != null)
            {
                spawnedJointIndicator = Instantiate(jointIndicatorPrefab, jointPoint, Quaternion.identity, weldTarget.transform);
                weldTarget.transform.parent = firstObject.transform;
                weldTarget.transform.position = firstObject.transform.position;
                weldTarget.GetComponent<Rigidbody>().isKinematic = true;
                carriedObject = weldTarget;
                carriedNormals = targetNormal;
            }
        }
        else
        {
            if (weldTarget != null)
            {
                if (weldMode == 0)
                {
                    Vector3 tempPos = spawnedJointIndicator.transform.localPosition;
                    spawnedJointIndicator.transform.parent = weldTarget.transform.root;
                    spawnedJointIndicator.transform.position = jointPoint;

                    pivot = spawnedJointIndicator.transform;
                    carriedObject.transform.parent = spawnedJointIndicator.transform;
                    carriedObject.transform.localPosition = -tempPos;
                    carriedObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    Destroy(carriedObject.GetComponent<Rigidbody>());
                    carriedObject = null;
                    spawnedJointIndicator = null;
                    weldTarget.transform.root.GetComponent<Rigidbody>().ResetCenterOfMass();
                }
            }
        }

    }

    private Transform pivot = null;
    public override void UseToolSecondary()
    {
        if (weldMode == weldmodeGraphics.Length -1)
        {
            weldMode = 0;
        }
        else
        {
            weldMode++;
        }
    }

    public override void UseToolRotation(Vector3 rotation)
    {
        if (pivot != null)
        {
            pivot.Rotate(rotation);
        }
    }




}
[System.Serializable]
public struct weldModeGraphic
{
    public Sprite icon;
    public string description;
}