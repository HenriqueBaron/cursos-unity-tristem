using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{

	int maximum;
	int minimum;
	int guess;

	// Use this for initialization
	void Start()
	{
		StartGame();		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//print("Up arrow pressed");
			minimum = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//print("Down arrow pressed");
			maximum = guess;
			NextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print("I won! Your choice was " + guess);
			StartGame();
		}
	}

	void StartGame()
	{
		maximum = 1000;
		minimum = 1;
		guess = 500;
		print("================================");
		print("Welcome to the Number Wizard");
		print("Pick a number in your head, but don't tell me!");

		print("The number must be between " + minimum + " and " + maximum);
		maximum++;

		print("Is the number higher or lower than " + guess + "?");
		print("Up = higher, down = lower, return = equal");
	}

	void NextGuess()
	{
		guess = (maximum + minimum) / 2;
		print("Higher or lower than " + guess + "?");
	}
}
