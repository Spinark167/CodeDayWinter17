using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//THIS IS LITERALLY THE SAME SCRIPT AS GROUNDCHECK BUT YOU CANT HAVE TWO SCRIPTS WITH THE SAME NAME SO I RENAMED IT

public class GroundChecker : MonoBehaviour {

	private Playerer player;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//its important to notet that the Player gameobject is the parent to the GroundDetector which is what this script gets attached to
		player = gameObject.GetComponentInParent<Playerer> ();//this gets the information about the player script from the Player gameobject
		rb = gameObject.GetComponentInParent<Rigidbody2D> ();//this gets the rigidbody information about the player from the Player gameobject
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){//notice that this is Trigger and not Collision. That is because Trigger is associated with colliders that are checked to be triggers (the 'Is Trigger' checkbox is checked in the inspector
		if (col.gameObject.tag == "Ground" && rb.velocity.y == 0) {//if what I'm colliding with has the tag of ground and I'm not moving up or down
			player.grounded = true;//I am grounded
		}
	}

	void OnTriggerStay2D(Collider2D col){//this is the same thing as the method above except it says stay instead of enter. This indicates that this method continues to run aslong as the colliders are in contact
		if (col.gameObject.tag == "Ground" && rb.velocity.y == 0) {
			player.grounded = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){//this runs when the gameobject exits a collision, then the grounded attribute is set false. Like if I jump, then my GroundDetector collider has to exit the ground collider.
		player.grounded = false;
	}
}
