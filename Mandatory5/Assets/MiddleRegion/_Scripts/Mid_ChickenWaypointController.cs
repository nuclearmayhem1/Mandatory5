using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Mid_ChickenWaypointController : MonoBehaviour
{
    public GameObject waypointParent;
    public List<Transform> waypoints;
    public NavMeshAgent _agent;
    

    //private float distance; 
    private int _index = 0;
    //private Transform chickenTransform;

    private void Awake()
    {
        foreach (Transform child in waypointParent.gameObject.transform)        //Adds all childs of waypointParent to the list of waypoints.
        {
            waypoints.Add(child.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 1f)               //If agents distance to waypoint is closer than 1, go to next waypoint.
        {
            GoToNextWaypoint();
        }
    }
    public void GoToNextWaypoint()
    {
                                                        // returns to the beginning of the list if there are no waypoints left.
        if (waypoints.Count == 0)
        {
            return;
        }
        _agent.SetDestination(waypoints[_index].position);              //Sets the destination to the next waypoint.
        _index = (_index + 1) % waypoints.Count;
    }
}
