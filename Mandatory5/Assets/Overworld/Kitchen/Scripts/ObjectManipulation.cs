using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class ObjectManipulation : MonoBehaviour
{
    [SerializeField] GameObject grabPoint, cameraRoot;
    [SerializeField] float grabStrenght = 5;
    [SerializeField] private float rayCastRange = 5;
    private float grabPointDistance = 3f;
    [SerializeField] private float grabPointMin, grabPointMax;
    [SerializeField] private ThirdPersonController playerController;
    [SerializeField] private float rotateXMultiplier = 1, rotateYMultiplier = 1, rotateZMultiplier = 5;
    [SerializeField] Transform carriedSlot;

    private void OnValidate()
    {
        if (grabPointMin <= 0)
        {
            grabPointMin = 0;
        }
        if (grabPointMax <= 1)
        {
            grabPointMax = 1;
        }
        if (grabPointMin > grabPointMax - 1)
        {
            grabPointMax = grabPointMin + 1;
        }
        if (grabPointMax < grabPointMin + 1)
        {
            grabPointMin = grabPointMax - 1;
        }
    }

    private bool rightClick = false;
    private bool holding = false;
    private GameObject carried = null;
    private void Update()
    {
        if (!holding && Input.GetMouseButtonDown(0))
        {
            holding = TryPickupObject();
        }
        else if (holding && Input.GetMouseButtonDown(0))
        {
            holding = DropObject();
        }

        if (!rightClick)
        {
            grabPointDistance += Input.GetAxis("Mouse ScrollWheel");
            grabPointDistance = Mathf.Clamp(grabPointDistance, grabPointMin, grabPointMax);
            grabPoint.transform.localPosition = new Vector3(0, 0, grabPointDistance);
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerController.freezePlayerCamera = true;
            rightClick = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            playerController.freezePlayerCamera = false;
            rightClick = false;
        }
        //Manipulate a held item
        if (holding)
        {
            Rigidbody heldRb = held.GetComponent<Rigidbody>();
            heldRb.velocity =  (grabPoint.transform.position - held.transform.position) * grabStrenght;
            heldRb.freezeRotation = true;

            if (rightClick)
            {
                float mouseX = Input.GetAxis("Mouse X") * rotateXMultiplier;
                float mouseY = Input.GetAxis("Mouse Y") * rotateYMultiplier;
                float scrollZ = Input.GetAxis("Mouse ScrollWheel") * rotateZMultiplier;
                Vector3 newRot = new Vector3(mouseY, mouseX, scrollZ);
                held.transform.Rotate(newRot);
            }
            if (Input.GetMouseButtonDown(2))
            {
                held.transform.rotation = playerController.CinemachineCameraTarget.transform.rotation;
            }
        }
        //Carry item on back
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (carried != null)
            {
                if (held != null)
                {
                    GameObject temp = held;
                    held = carried;
                    held.transform.position = grabPoint.transform.position;
                    held.GetComponent<Rigidbody>().freezeRotation = true;
                    held.GetComponent<Rigidbody>().isKinematic = false;
                    held.transform.parent = null;
                    carried = temp;
                    carried.transform.parent = carriedSlot;
                    carried.transform.localPosition = Vector3.zero;
                    carried.GetComponent<Rigidbody>().freezeRotation = true;
                    carried.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {
                    held = carried;
                    held.transform.parent = null;
                    held.transform.position = grabPoint.transform.position;
                    held.GetComponent<Rigidbody>().isKinematic = false;
                    carried = null;
                    holding = true;
                }
            }
            else
            {
                if (held != null)
                {
                    carried = held;
                    carried.transform.parent = carriedSlot;
                    carried.transform.localPosition = Vector3.zero;
                    carried.GetComponent<Rigidbody>().freezeRotation = true;
                    carried.GetComponent<Rigidbody>().isKinematic = true;
                    held = null;
                    holding = false;
                }
            }
        }
    }


    private GameObject held;
    private bool TryPickupObject()
    {
        Ray ray = new Ray(transform.position, cameraRoot.transform.forward);
        Physics.Raycast(ray, out RaycastHit hit, rayCastRange);
        if (hit.collider == null)
        {
            return false;
        }

        if (hit.collider.transform.root.TryGetComponent<InteractOnClick>(out InteractOnClick onClick))
        {
            onClick.Clicked();
            return false;
        }

        if (hit.collider.transform.root.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            if (hit.collider.transform.root.gameObject.tag == "Manipulatable")
            {
                held = hit.collider.transform.root.gameObject;
                held.transform.position = grabPoint.transform.position;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private bool DropObject()
    {
        held.GetComponent<Rigidbody>().freezeRotation = false;
        held = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, cameraRoot.transform.rotation * Vector3.forward * rayCastRange + transform.position);
        Gizmos.DrawWireSphere(grabPoint.transform.position, 0.1f);
        Physics.Raycast(new Ray(transform.position, cameraRoot.transform.forward), out RaycastHit hit, rayCastRange);
        if (hit.collider != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(hit.point, Vector3.one * 0.1f);
        }
    }
}
