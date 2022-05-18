using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    [SerializeField] GameObject grabPoint, cameraRoot;
    [SerializeField] float grabStrenght = 5;
    [SerializeField] private float rayCastRange = 5;

    private bool holding = false;
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

        if (holding)
        {
            Rigidbody heldRb = held.GetComponent<Rigidbody>();
            heldRb.velocity =  (grabPoint.transform.position - held.transform.position) * grabStrenght;


            //heldRb.isKinematic = true;
            //heldRb.MovePosition(grabPoint.transform.position);
            //Vector3.Lerp(held.transform.position, grabPoint.transform.position, 0.1f);
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
        //held.GetComponent<Rigidbody>().isKinematic = false;
        held = null;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, cameraRoot.transform.rotation * Vector3.forward * rayCastRange + transform.position);
    }
}
