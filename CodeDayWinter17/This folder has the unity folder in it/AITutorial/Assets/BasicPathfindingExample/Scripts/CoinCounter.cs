using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;//HEY LOOK UP HERE YOU HAVE TO HAVE THIS IS YOU WANT SCENE TRANSISTIONS
using UnityEngine;

public class CoinCounter : MonoBehaviour {

	//static means its contained to this script
	//public means that the value can be accessed from the unity editor itself
    static int coins = 0;
    public int maxCoins = 0;//this is set to zero here but you need to set it to the correct value in the editor which you can do becasue its public

	//this method is static, it returns nothing and it increments the value of coins by 1 (thats what ++ does)
    public static void addToCoins()
    {
        coins++;
    }
	
	// Update is called once per frame (also known as the game loop)
	void Update () {
		if(coins == maxCoins)//if this equals the max coin value then
        {
            coins = 0; //reset the counter
            SceneManager.LoadScene(0); //restart the scene (the zero represents this scene
			//THE LINE ABOVE THIS IS ONE OF THOSE SCENE TRANSITION MOMENTS THAT WE NEED LINE 3 FOR
        }
	}
}
