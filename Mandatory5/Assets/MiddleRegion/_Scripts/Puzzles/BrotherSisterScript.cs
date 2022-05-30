using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherSisterScript : MonoBehaviour
{
    public GameObject[] brotherObjects;
    public List<Transform> brotherTransforms;
    public Transform bestTarget = null;
    float closestDistanceSqr = Mathf.Infinity;
    Vector3 currentPosition, directionToTarget;

    public void Start()
    {
        brotherObjects = GameObject.FindGameObjectsWithTag("Brother");
        foreach (var brotherObject in brotherObjects)
        {
            brotherTransforms.Add(brotherObject.GetComponent<Transform>());
        }
    }
    public void Update()
    {
        if (gameObject.tag == "Sister")
        {
            GetClosestBrother();
        }
    }
    public void GetClosestBrother()
    {
        foreach (Transform currentTarget in brotherTransforms)
        {
            currentPosition = transform.position;
            directionToTarget = currentTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = currentTarget;
                Debug.Log(currentTarget);
            }
        }
    }
}
