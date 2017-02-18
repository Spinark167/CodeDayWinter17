/*
 * Hi so the purpose of this 'script' is to show you all some coding things.
 * So first of all this is a comment and what that means is that the computer 
 * will not read this text. A comment is made just for the user of the file.
 * It is important to note that this is a multipule lined comment and 
 * it is written by starting with a forward slash then a start - you then write 
 * your comments and then you end by typing a star then another forward slash.
 * */
// this is a single line comment, they're made with double forward slashes.

//this file is full of errors so don't include it in your project, its just for reading and yeah.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The name of the file in unity must be exatly the same as the one found here (Information). So if you want to change the name, you must change it in both locations.
public class Information : MonoBehaviour {
	
	// variables are things in coding that can hold information
	//you make them by giving a type then a name, then assigning a value.
	int myNumber = 5;
	//so I just made an integer called 'myNumber' and it is equal to five.
	//I can then change the variable
	myNumber = 3;
	//so now my integer called 'myNumber' is equal to three
	//I can also do operations
	myNumber = myNumber * 6;
	//so now my integer called 'myNumber' is equal to 18
	//notice that all of these lines end in a ;
	//all statements to the computer must end in a ;

	//LOGIC STUFF
	//if statement
	if(myNumber > 5)//this say almost like an english comment, if: myNumber is greater than 5. If that is true, the code inside the {} will run
	{
		myNumber = 4; //since myNumber was equal to 18, the statement would have been true and this line would run. This line makes myNumber be less than 5 since it sets it equal to 4
	} 

	if(myNumber > 5)
	{
		myNumber = 4;
	} 
	else 
	{//the else means that is the top expression evaluates to false, then fun this code
		myNumber = 6;//since myNumber equals four now, this part will run since 4 is not greater than 5
	}

	//to compare number we have 
	//equals: ==
	//greater than: >
	//less than: <
	//less than or equal to: <=
	//greater than or equal to: >=
	//not equal to: !=
	//and: &&
	//or: ||

	//there are also boolean type variables which are either true or false only.
	bool hasDied = false;//I'm not dead
	bool amAlive = true;//I'm alive

	//we can also chain if else statements
	if(hasDied)
	{
		//code here wouldn't run becasue hasDied is false
	} 
	else if(amAlive)
	{
		//code here would run since amAlive is true
	} 
	else 
	{
		//code here wouldn't run becuase amAlive is true. In these if else if things, one one expression is found to be true, that code is ran and then the computer jumps to the end of the if else tree.
	}

	//METHODS
	//they do things. They can take in values and they can output values.
	//here is their format:
	//scope - return type - name of method - parameters - {}
	//example:
	public float MultiplyByFive(float aNumber)//the public is the scope, the float is the return type, the MultiplyByFive is the name, the float aNumber is the parameter that the method takes in
	{
		return aNumber * 5f;//all float values have to have an f after them just because thats how things work
		//the keyword return is what specifies what the method returns
		//so this method returns 5 times some inputed value.
	}

	//most methods that we will be using dont have return type though so you write void in for the return type. 

	//a static method can be called from anywhere within the project.
	public static void EndGame()
	{
		//somehow write code so that the program closes when this method is called.
	}

	//to call a method you simply type .TheMethodName or TheMethodName depending on whats going on
	int newValue = MultiplyByFive(myNumber); //this will set newValue to whatever 5*myNumber is

	//static methods are called by typing the name of the script followed by a . then the name of the method
	//forexample:
	Information.EndGame(); //this is especially useful because this can be called from anywhere

	//other key concepts specifically related to unity can be found in scripts that actually do things. 

}
