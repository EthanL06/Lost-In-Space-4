using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1;
    public float reachDist = 1.0f;
    public int currentWaypoint = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(waypoints[currentWaypoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * speed);

        if (dist <= reachDist) {
            currentWaypoint++;
        }

        if (currentWaypoint >= waypoints.Length) {
            currentWaypoint = 0;
        }
    }
}
