using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PushShroomStopper : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float stopRadius = 5f;

    private bool hasSpoken = false;
    [SerializeField] private GameObject dialogue;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        hasSpoken = false;
    }

    void Update()
    {
        if (hasSpoken)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, stopRadius);

                //Looping through each collider within a radius to find the player
                foreach (Collider c in colliders)
                {
                    if (c.CompareTag("Player"))
                    {
                        //Setting all velocity to zero to stop momentum
                        _rb.velocity = Vector3.zero;
                        _rb.angularVelocity = Vector3.zero;
                        Debug.Log("STOPPING MOMENTUM");
                    }
                }
            }
        }
        else
        {
            _rb.constraints = RigidbodyConstraints.FreezeAll;
            
            if (dialogue.GetComponentInChildren<ChickenCanvasController>().speechBubbleText != null)
            {
                if (dialogue.GetComponentInChildren<ChickenCanvasController>().speechBubbleText.GetComponent<MidDialogue>().dialogueNumber ==
                    4)
                {
                    //Remove Physics constraints so the shroom can be pushed around
                    _rb.constraints = RigidbodyConstraints.None;
                    dialogue.SetActive(false);
                    hasSpoken = true;
                }
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Visual Gizmos to show range of which the player can stop the shroom
        Gizmos.color = new Color(1, 1, 1, 0.7f);
        Gizmos.DrawSphere(transform.position, stopRadius);
    }
}
