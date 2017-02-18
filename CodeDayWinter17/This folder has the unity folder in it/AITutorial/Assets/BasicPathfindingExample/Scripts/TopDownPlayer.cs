using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    // Normal Movements Variables
    private float walkSpeed;
    private float sprintSpeed;
    private float curSpeed;//current speed
    private float maxSpeed;

    private Rigidbody2D rigid;//a rigid body is what allows an object to interact with physics applied to it

    private CharacterStat plStat; //this is an instance of the other script CharacterStat

	//this is called once at the start of a scene
    void Start()
    {
        plStat = GetComponent<CharacterStat>(); //this gets the actual information of the CharacterStat on this gameobject
        rigid = GetComponent<Rigidbody2D>(); //this gets the actual information of the Rigidbody2D on this gameobject

        walkSpeed = (float)(plStat.speed + (plStat.agility / 5));//this pulls speed variables and agility variables from the plStat class
        sprintSpeed = walkSpeed + (walkSpeed / 2);
		//assignments for potential use later
        curSpeed = walkSpeed;
        maxSpeed = walkSpeed;
    }

    void FixedUpdate()//use FixedUpdate for anything involving physics that you need to do. So like movement 
    {
        rigid.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),//dont question the Lerp, it is what it is, it not 100% necessary but its there in this project
                                       Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
}