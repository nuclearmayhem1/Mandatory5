using System;
using System.Collections;
using System.Collections.Generic;
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

            //Looping through each collider within a radius to find the player
            foreach (Collider c in colliders)
            {
                //If player is within the radius
                if (c.CompareTag("Player"))
                {
                    //Give hint
                    if (!startFade)
                    {
                        startFade = true;
                        hintText.color = Color.clear;
                    }
                        
                }
            }
        }

        if (startFade)
        {
            hintText.color = Color.Lerp(hintText.color, Color.yellow, Time.deltaTime * textFadeSpeed);

            if (hintText.color == Color.yellow)
            {
                hintText.color = Color.clear;
                startFade = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.7f);
        Gizmos.DrawSphere(transform.position, hintRadius);
    }
}
