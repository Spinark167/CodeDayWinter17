using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS LITERALLY THE SAME SCRIPT AS PLAYER BUT SINCE YOU CANT HAVE TWO SCRIPTS OF THE SAME NAME, I RENAMED IT

public class Playerer : MonoBehaviour {

	//Declare public class variables
	//moveSpeed is multiplied by horizontal velocity to adjust speed of player.
	public float moveSpeed = 5.0f;

	//jumpPower is multiplied by vertical velocity to adjust jump height
	public float jumpPower = 6.5f;

	//Used to prevent jumping in mid air by the player. Is equal to true when player is touching ground
	public bool grounded;

	public int playerHealth = 10;
	public int maxPlayerHealth = 10;

	//Particle effect to be played when the player is destroyed
	public GameObject deathParticleEffect;

	//Is added to the y coordinate of the instantiation of particles in order to make it appear a bit above the player's center
	public float particleInstantiationHeight = 2f;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		//Initialize compoenents of player
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Sets a max for the amount of health that the playr can have at any one time
		if (playerHealth > 10)
		{
			playerHealth = maxPlayerHealth;
		}

		//What happpens when the player dies
		if (playerHealth <= 0)
		{
			Destroy (gameObject);
			Instantiate(deathParticleEffect, new Vector2(transform.position.x, transform.position.y + particleInstantiationHeight), transform.rotation);//the instantiate call creates a game object, see more on it in the bassic shooting folder
		}

		//controls which direction the sprite is facing depending on which direction the player is moving
		if (Input.GetAxis ("Horizontal") < -.1f)//if going left
		{
			transform.localScale = new Vector3 (-1, 1, 1);//scale it to make it look left
		}
		if (Input.GetAxis ("Horizontal") > .1f)//if going right
		{
			transform.localScale = new Vector3 (1, 1, 1);//scale it to make it look right
		}
	}

	void FixedUpdate(){
		//Gets keyboard input from player for horizontal axis
		float horizontalInput = Input.GetAxis ("Horizontal");

		//this is what actually moves the player
		rb2d.velocity = new Vector2 (moveSpeed * horizontalInput, rb2d.velocity.y);//setting x velocity based on default movement speed and userinput gathered 3 lines above

		//controls jumping
		if ((Input.GetButtonDown ("Jump") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && grounded)// if the user inputs space, uparrow, or w
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpPower);//set y velocity based on a default jumpPower value
		}
	}
}
