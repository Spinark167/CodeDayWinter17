using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	//this holds info on the buller
	public GameObject bullet;

	//so you can't spam fire, theres a timer that will dictate the time there needs to be between shots
	float timer = 0f;

	//these will contain info on the x and y positions of the mouse and the player
	float mouseY;
	float mouseX;
	float myY;
	float myX;

	//this will be the dist to the mouse
	float distToMouse;

	//this will dictate the speed of the bullet
	public float shootFactor = 50f;

	//this is needed because it is
	public Camera camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//these are used to set up some ratios. This is where the mathy stuff comes in
		mouseY = Input.mousePosition.y;
		mouseX = Input.mousePosition.x;
		myY = camera.WorldToScreenPoint(gameObject.transform.position).y;
		myX = camera.WorldToScreenPoint(gameObject.transform.position).x;

		//using the distance formula with the sqrt this time because i need the actual distance for a calculation later
		distToMouse = Mathf.Sqrt ((mouseX - myX) * (mouseX - myX) + (mouseY - myY) * (mouseY - myY));

		//if a fire button is hit and if the timer is less than or equal to zero
		if (((Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0))) && (timer <= 0)) {
			Shoot ();//shoot
			timer = .25f;//set the timer up again
		}
	}

	public void Shoot(){
		//this creates and shoots a bullet. Its kind of complicated and just go with it for now
		GameObject newObj = Instantiate (bullet, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
		newObj.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((mouseX - myX) * shootFactor / distToMouse /*+ gameObject.GetComponent<Rigidbody2D> ().velocity.x*/, (mouseY - myY) * shootFactor / distToMouse);
	}

	//explained earlier
	void FixedUpdate(){
		timer -= .02f;
	}
}
