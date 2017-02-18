using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this class is to drestroy the "bullets" when they hit things

public class dieOnContact : MonoBehaviour {

	//we also dont want our bullets to be chilling inspace for ever if they dont hit anything, that takes up memory and can slow things down
	//lets make a timer
	public float dieTime = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		Destroy (gameObject);//destroys this gameobject

		//maybe if we wanted to dammage something with out bullets, we could have an if statement before the destroy command that check the tag of what was collided with
		//then possibly a static method could be called to increase or decrese health or activate something, be creative
	}

	void FixedUpdate(){
		dieTime -= .02f;//the fixed update is suppose to be called every .02 seconds, therefore, if subtracting .02 each fixed update acts to take off .02 from the timer

		if (dieTime <= 0) {//when the time is over destroy the gameobject
			Destroy (gameObject);
		}
	}
}
