using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class InteractionController : MonoBehaviour
{
    [SerializeField] private SphereCollider col;
    [SerializeField] private float radius = 2;
    [SerializeField] private KeyCode interactKey = KeyCode.F;
    [SerializeField] private UnityEvent onInteract;

    private void Reset()
    {
        col = GetComponent<SphereCollider>();
        col.isTrigger = true;
    }

    private bool hasPressed = false;
    private float timeUntilForget = 0;
    private void Update()
    {
        if (!hasPressed)
        {
            if (Input.GetKeyDown(interactKey))
            {
                hasPressed = true;
                timeUntilForget = 1f;
            }
        }
        if (timeUntilForget > 0)
        {
            timeUntilForget -= Time.deltaTime;
        }
        else
        {
            hasPressed = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasPressed)
        {
            hasPressed = false;
            onInteract.Invoke();
        }
    }


    private void OnValidate()
    {
        if (col == null)
        {
            col = GetComponent<SphereCollider>();
            col.isTrigger = true;
        }
        if (radius < 0.1f)
        {
            radius = 0.1f;
        }
        col.radius = radius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
