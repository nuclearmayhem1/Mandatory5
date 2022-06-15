using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class HintStoneBehaviour : MonoBehaviour
{
    [SerializeField] private float hintRadius;
    [SerializeField] private TMP_Text hintText;

    [SerializeField] private float textFadeSpeed;
    private bool startFade = false;

    private void Start()
    {
        startFade = false;
        hintText.color = Color.clear;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, hintRadius);

            if (colliders.ToList().Any(x => x.CompareTag("Player")))
            {
                //If player is in radius change text color to yellow
                hintText.color = Color.yellow;
            }
            else
            {
                //Make text transparent when player is not within range
                hintText.color = Color.clear;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.7f);
        Gizmos.DrawSphere(transform.position, hintRadius);
    }
}
