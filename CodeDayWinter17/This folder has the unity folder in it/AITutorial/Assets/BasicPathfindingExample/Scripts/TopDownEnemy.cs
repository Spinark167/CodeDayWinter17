using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this is the script that controls the actions of the enemy
public class TopDownEnemy : MonoBehaviour {

	//an enum just allows for name calling. hopefully that will make more sense later in this script
    public enum States {Default, Follow};

    public List<Transform> waypoints;//a List holds information on items. The items for this list are 'Transform's
    public States state;
    public int currWayPoint = 0;
    public Transform player;

	//notice these are the same as the things from TopDownPlayer
    private float walkSpeed;
    private float sprintSpeed;
    private float curSpeed;
    private float maxSpeed;

	//this is used to control how close you get to a waypoint
    public float threshold = .05f;

    Rigidbody2D rigid;

    private CharacterStat enStat;

    // Use this for initialization
    void Start () {
		//again we get our info on our rigid body and our stats about movement
        rigid = GetComponent<Rigidbody2D>();
        enStat = GetComponent<CharacterStat>();

		//again we assign the variables in the script bases on data recovered from other scripts
        walkSpeed = (float)(enStat.speed + (enStat.agility / 5));
        sprintSpeed = walkSpeed + (walkSpeed / 2);

        curSpeed = walkSpeed;
        maxSpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void FixedUpdate () {
        Vector3 moveTo = new Vector2();//vectors have direction and magnitude. A Vector 3 works in 3D space, a Vector w works in 2D space
        switch (state)//switch statments are kinda like an if elseif else structure
        //it takes in a value, here it is state
		{
            case States.Default://it says is the state default?
                moveTo = waypoints[currWayPoint].position;//if so, we try to go to the next waypoint
                break;//we then exit the switch statement before the rest of the switch statement is run
            case States.Follow://it says is the state follow?
                moveTo = player.position;//if so, we try to go to the player
                break;//we the exit the switch statement
        }
        Vector2 dir = (moveTo - transform.position).normalized;//this involves some vector math. 
		//basically if you subtract the position of one thing from the other, you get a vector that points from one to the other
		//the order of subtractions dictates the direction of the vector, play around with it to see which way is which

        rigid.velocity = dir * curSpeed; //.velocity is literally the velocity of the object
        if((waypoints[currWayPoint].position - transform.position).magnitude < threshold)//if you are closer than the threshold to the waypoint
        {
            currWayPoint++;//go to the next waypoint
            if(currWayPoint >= waypoints.Count)//if youre looking at a way point thats not there, youve just left the last way point in the list and need to go back to the first
            {
                currWayPoint = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)//when the enemy collides with something
    {
        if (coll.gameObject.name.Equals("player"))//if it is named the player
        {
            state = States.Follow;//it goes to the follow state
        }
    }

    void OnTriggerExit2D(Collider2D coll)//when the enemy exits a collision with something
    {
        if (coll.gameObject.name.Equals("player"))//if the something is the player
        {
            state = States.Default;//go back to following the waypoints.
        }
    }
}
