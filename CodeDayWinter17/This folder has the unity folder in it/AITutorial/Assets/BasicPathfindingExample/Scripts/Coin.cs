/*
This is the script for the little yellow coins that you see in this scene.
*/
//dont worry about these top three lines, the just allow your computer to know that this 
//script will be working with unity's stuff 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	
    void OnTriggerEnter2D(Collider2D coll)//when this gameobject encounters a collision with another gameobject
    {
        if (coll.gameObject.name.Equals("player"))//if coll, the object that collided with this game object has the name of "player" <- that is case sensitive
        {
            CoinCounter.addToCoins();//this calls the static method 'addToCoins' from the CoinCouter script
            Destroy(this.gameObject);//deletes the coin from the scene
        }
    } 

}
