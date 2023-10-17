// Script for handling player character
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Sets up the player character for gameplay mechanics
	private Rigidbody playerRb;
	public float jumpForce;
	public float gravityModifier;
	public bool isOnGround = true;
	public bool gameOver = false;
	
	// Configures animation and audio
	private Animator playerAnim;
	public ParticleSystem explosionParticle;
	public ParticleSystem dirtParticle;
	public AudioClip jumpSound;
	public AudioClip crashSound;
	private AudioSource playerAudio;
	
	private int playerScore;
	
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
		Physics.gravity *= gravityModifier;
		isOnGround = true;
		playerAudio = GetComponent<AudioSource>();
        InvokeRepeating("AddScore", 3, 2); // Starts counting score over time
    }
	
    void Update()
    {
		//Checks if player is dead and on ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
			
			// Controls player character jump action
        	playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
			
			// Sets sounds and animations for jumping
			playerAnim.SetTrigger("Jump_trig");
			dirtParticle.Stop();
			playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
	
	// Handles player when collision with ground or obstacle is detected
	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Ground")) {
			isOnGround = true;
			dirtParticle.Play();
		} 
		
		// Handles game over sequence if player hits obstacle
		else if (collision.gameObject.CompareTag("Obstacle")) {
			gameOver = true;
			Debug.Log("Game Over!");
			Debug.Log("Final score: " + playerScore);
			playerAnim.SetBool("Death_b", true);
			playerAnim.SetInteger("DeathType_int", 1);
			playerAudio.PlayOneShot(crashSound, 1.0f);
			explosionParticle.Play();
			dirtParticle.Stop();
		}
	}
	
	void AddScore()
	{
		if (!gameOver){ // Checks if the player is dead and adds to score periodically if not
			playerScore++;
			Debug.Log("Current score: " + playerScore);
		}
	}
	
}
