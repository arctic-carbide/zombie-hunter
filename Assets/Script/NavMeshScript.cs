using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    NavMeshAgent agent;
    int nextPoint = -1;
    private Transform[] waypoints = null;
    int currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.Find("Waypoints").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        do
        {
           nextPoint =  Random.Range(0, waypoints.Length - 1);
        }
        while (nextPoint == currentTarget);

        currentTarget = nextPoint;

        agent.SetDestination(waypoints[currentTarget].position);
    }
}
