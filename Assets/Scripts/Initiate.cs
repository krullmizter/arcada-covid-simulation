using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiate : MonoBehaviour {
    public GameObject prefab;
    public int maxSpawns = 8;
    public Material covidRed;

    void Start() {
        Spawn();
        Infect();
    }

    void Spawn() {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("spawnPoint");

        if (maxSpawns > spawns.Length) { // If the maxSpawns value is larger than the amount of spawnpoints then set the maxspawns to the current length of the spawns array.
            maxSpawns = spawns.Length;
        }

        int random = Random.Range(2, maxSpawns); // Calculate amount of randoms players to spawn, min 2.
        
        for (int i = 0; i < maxSpawns; i++) {
             Instantiate(prefab, spawns[i].transform.position, Quaternion.identity);
        }
    }

    void Infect() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int random = Random.Range(0, players.Length);

        GameObject patientZero = players[random]; // Choose random player to become patient zero.

        patientZero.GetComponent<MeshRenderer>().material = covidRed;
        patientZero.GetComponent<Covid>().infected = true;

        patientZero.name = "Patient Zero";

        Debug.Log("Total amount of players: " + players.Length);
    }
}
