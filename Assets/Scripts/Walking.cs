using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {
    public int speed = 5;
    private GameObject[] waypoints;
    private UnityEngine.AI.NavMeshAgent player;
    private int random;

    void Start() {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        player    = GetComponent<UnityEngine.AI.NavMeshAgent>();

        NextWaypoint();
    }

    void Update() {
        if (player.remainingDistance < 5.0f && !player.pathPending) { // if the players remaining distance to current waypoint is smaller than given number, and it doesn't have a pending path choose new waypoint.
            NextWaypoint();
        }
    }

    void NextWaypoint() {
        random = Random.Range(0, waypoints.Length - 1);
        player.speed = speed;
        player.destination = waypoints[random].transform.position;
    }
}