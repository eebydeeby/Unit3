// Spawns new objects periodically
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject obstaclePrefab;
	private Vector3 spawnPos = new Vector3(25, 2, 0); // Invokes method to spawn new objects
	private float startDelay = 2;
	private float repeatRate = 2;
	private PlayerController playerControllerScript;
	
    void Start() {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
		playerControllerScript =
			GameObject.Find("Player").GetComponent<PlayerController>(); // Gets the game over state from the player object
    }

	void SpawnObstacle () { // Spawn obstacle
		if (playerControllerScript.gameOver == false) { // Checks if player is in game over state
			Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
		}
	}
}
