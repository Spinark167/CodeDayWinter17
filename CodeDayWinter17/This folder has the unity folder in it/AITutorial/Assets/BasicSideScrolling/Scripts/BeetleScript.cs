using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//this script is meant to be placed on an enemy or a beetle
public class BeetleScript : MonoBehaviour {

	//we need holders to store info on the player and the enemy's rigidbody
	public GameObject player; 
	private Rigidbody2D rb;

	//this value is going to be used to represent the square of the distance between the beetle an the player
	//the actual distance formula involves a square root, but square roots are very taxing on a machine, so to 
	//make games run smoother, the square of the distance is used
	float distToPlayerSqrd = 100f;

	float direction = 1f;
	float health = 3f;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//this is basic distance formula or pythagorean theorem 
		distToPlayerSqrd = (player.transform.position.x - gameObject.transform.position.x) * (player.transform.position.x - gameObject.transform.position.x) + (player.transform.position.y - gameObject.transform.position.y) * (player.transform.position.y - gameObject.transform.position.y);

		//pretending that there is a way to decrement the enemy health, if it hits zero, the enemy should die
		if (health <= 0) {
			//maybe a static method could get called here that increments a points counter
			Destroy (gameObject);
		}

		//this if statement is saying: if the player is to the right of the enemy
		if ((player.transform.position.x - gameObject.transform.position.x) >= 0) {
			direction = 1f;//move to the right
			gameObject.transform.localScale = new Vector3 (-.05f, 1f, 1f);//look to the right
		}
		if((player.transform.position.x - gameObject.transform.position.x) < 0) {//if the player is t the left of the beetle
			direction = -1f;//move left
			gameObject.transform.localScale = new Vector3 (.05f, 1f, 1f);//look left
		}

	}

	//physics based things happen here
	void FixedUpdate(){
		if (distToPlayerSqrd < 400f) {//if the player is within 20 units (remember our distToPlayerSqrd is the square of the distance so 20*20 = 400
			rb.velocity = new Vector2 (2f * direction, rb.velocity.y);//we need to move and notice our movement is based on the 'direction' variable that is determined above
		} else {
			rb.velocity = new Vector2 (0f, rb.velocity.y);//if the player is too far away, it should move exept in the y
		}
	}

	//this method was made for a different game, but lets say that that we had a fire ball type thing that would kill the enemy if the enemy got hit by enough of them, then this is what we'd need
	void OnCollisionEnter2D(Collision2D other){//when something colides with me
		if (other.gameObject.tag == "FireBall") {//if that other thing has a tag that is FireBall
			health--;//decrement my health by 1 (thats what -- means)
		}
	}
}
