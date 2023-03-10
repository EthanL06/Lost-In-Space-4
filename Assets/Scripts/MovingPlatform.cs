using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform[] waypoints;
    public Transform currentWaypoint;
    public int currentWaypointIndex = 0;
    public float speed = 1f;
    public float waitTime = 1f;
    public bool isWaiting = false;


    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints[currentWaypointIndex];    
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting) {
            return;
        }

        if (transform.position == currentWaypoint.position) {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }
            currentWaypoint = waypoints[currentWaypointIndex];
            StartCoroutine(Wait());
        }
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, speed * Time.deltaTime);
    }

    IEnumerator Wait() {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        isWaiting = false;
    }

    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.tag == "Player") {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.transform.parent = null;
        }
    }
}
