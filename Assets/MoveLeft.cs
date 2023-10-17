// Handles objects (background, obstacles) moving left
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
	private float speed = 10;
	private PlayerController playerControllerScript;
	private float leftBound = -15; // Sets up bounds for objects to be destroyed past
	
	void Start() {
		playerControllerScript =
		GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
    void Update()
    {
		if (playerControllerScript.gameOver == false) {
        	transform.Translate(Vector3.left * Time.deltaTime * speed);
		}
		
		// Destroys object if found out of bounds
		if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) {
			Destroy(gameObject);
		}
    }
}