using UnityEngine;
using System.Collections;

//Due to the nature of sprite and the movement of a side scroller, making a script for the camera to follow the player makes life easier. 
//This script is intended to be attached to the main camera
public class CameraFollow : MonoBehaviour {

	//we need info on the player so we make a public GameObject to store that info
	public GameObject player; 

	//this will be the place holders of the players x and y position
	float posX = 0.0f;
	float posY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		posX = player.transform.position.x;//we always need to be getting the position of the player
		posY = player.transform.position.y + 4.115f;//the camera should be above the player a bit so thats what the additional 4.115f is for

		//this next line says: this gameobjects position should be at the 3D coordinate, ((posX, posY, my current z position)
		//so basically, since this gameobject is the camera, the camera is getting places at and x and y value that are determined by the players position
		gameObject.transform.position = new Vector3 (posX, posY, gameObject.transform.position.z);
	}
}
