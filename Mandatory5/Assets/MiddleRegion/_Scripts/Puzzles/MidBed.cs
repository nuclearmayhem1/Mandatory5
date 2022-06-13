using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Quests;

public class MidBed : MonoBehaviour
{
    private bool withinRange, activated;
    public Material[] skyboxes;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
        
    private void Start()
    {
        //QuestMenuRenderer.currentWorld = Quest.World.ChickRepublic;
        //QuestManager.AddQuest(new Quest(Quest.World.ChickRepublic, "Go to sleep", 1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            withinRange = false;
        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && withinRange && !activated)
        {
            StartCoroutine("Sleeb");
        }
    }

    

    private IEnumerator Sleeb()
    {
        //while ()
        
        activated = true;
        GameObject.Find("Directional Light").GetComponent<Light>().color = new Color32(49, 44, 30, 1);
        
        RenderSettings.skybox = skyboxes[0];
        
        yield break;
        
    }
}
