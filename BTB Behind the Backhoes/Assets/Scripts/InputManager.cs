//***********************************************************
// Simple Unity Input Manager Script by R. Thomas James
// Please do not use without permission.
//***********************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager 
{
	private static int defInput = 0; 	// Controlls default input for methods without any parameters
										// Keyboard = 0; First Controller = 1; Second Controller = 2;
//How to use this:
	//Create New Input Axes in unity input manager
		//One for each axis or button required plus one for every type of controller used.
		//i.e. for a two player (local) game where keyboard, xbox controller and ps4 controllers are used you need 1 input for keyboard, 2 for xbox (because 2 xbox controllers may be used), and 2 for ps4 
		//FOR EVERY ACTION
		//Controller Axis: 
				//Name: Name_Device(P#)
				//Gravity: 1
				//Dead: 0.19
				//Sensitivity: 1
				//Type: Joystick Axis
				//Axis: Axis #
				//Joy Num: Joystick #
		//Keyboard Axis: 
				//Name: Name_KB
				//Negative Button: button
				//Positive Button: button
				//Gravity: 1000
				//Dead: 0
				//Sensitivity: 1000
				//Type: Key or Mouse Button
		//Controller Button:
				//Name: Name_Device(P#)
				//Positive Button: joystick # button
				//Gravity: 1000
				//Dead: 0
				//Sensitivity: 1000
				//Type: Key or Mouse Button
		//Keyboard Button:
				//Name: Name_KB
				//Positive Button: button
				//Gravity: 1000
				//Dead: 0
				//Sensitivity: 1000
				//Type: Key or Mouse Button

	//After the input manager has been updated:
	//Create 2 overloaded methods for each action (i.e. bool Fire(), bool Fire(int))

	//To call the method in other scripts: InputManager.SampleAction();
	//This script is static so it does not have to be attached to a gameobject in the scene.
// Sample Code
	/*
	public static float SampleAxis()
	{
		switch (defInput) {

		case 0:
			return Input.GetAxis ("SampleAxis_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetAxis ("SampleAxis_PS(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetAxis ("SampleAxis_XB(P" + defInput + ")");
			} else {
				return 0f;
			}

			break;
		}
	}

	public static float SampleAxis(int playerNum)
	{
		switch (playerNum) {

		case 0:
			return Input.GetAxis ("SampleAxis_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetAxis ("SampleAxis_PS(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetAxis ("SampleAxis_XB(P" + playerNum + ")");
			} else {
				return 0f;
			}

			break;
		}
	}

	public static bool SampleButton()
	{
		switch (defInput) {

		case 0:
			return Input.GetButton ("SampleButton_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetButton ("SampleButton(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetButton ("SampleButton(P" + defInput + ")");
			} else {
				return false;
			}

			break;
		}
	}

	public static bool SampleButton(int playerNum)
	{

		switch (playerNum) {

		case 0:
			return Input.GetButton ("SampleButton_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetButton ("SampleButton_PS(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetButton ("SampleButton_XB(P" + playerNum + ")");
			} else {
				return false;
			}

			break;
		}
	}
	*/
	public static float MainHorizontal()
	{
		switch (defInput) {

		case 0:
			return Input.GetAxis ("MainHorizontal_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetAxis ("MainHorizontal_XB(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetAxis ("MainHorizontal_XB(P" + defInput + ")");
			} else {
				return 0f;
			}

			break;
		}
	}

	public static float MainHorizontal(int playerNum)
	{
		switch (playerNum) {

		case 0:
			return Input.GetAxis ("MainHorizontal_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetAxis ("MainHorizontal_XB(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetAxis ("MainHorizontal_XB(P" + playerNum + ")");
			} else {
				return 0f;
			}

			break;
		}
	}

	public static float MainVertical()
	{
		switch (defInput) {

		case 0:
			return Input.GetAxis ("MainVertical_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetAxis ("MainVertical_XB(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetAxis ("MainVertical_XB(P" + defInput + ")");
			} else {
				return 0;
			}

			break;
		}
	}

	public static float MainVertical(int playerNum)
	{
		switch (playerNum) {

		case 0:
			return Input.GetAxis ("MainVertical_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetAxis ("MainVertical_XB(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetAxis ("MainVertical_XB(P" + playerNum + ")");
			} else {
				return 0;
			}

			break;
		}
	}

	public static float AltHorizontal()
	{
		switch (defInput) {

		case 0:
			return Input.GetAxis ("AltHorizontal_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetAxis ("AltHorizontal_PS(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetAxis ("AltHorizontal_XB(P" + defInput + ")");
			} else {
				return 0;
			}

			break;
		}
	}

	public static float AltHorizontal(int playerNum)
	{
		switch (playerNum) {

		case 0:
			return Input.GetAxis ("AltHorizontal_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetAxis ("AltHorizontal_PS(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetAxis ("AltHorizontal_XB(P" + playerNum + ")");
			} else {
				return 0;
			}

			break;
		}
			
	}
		
	public static bool Boost()
	{
		switch (defInput) {

		case 0:
			return Input.GetButton ("Boost_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetButton ("Boost_PS(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetButton ("Boost_XB(P" + defInput + ")");
			} else {
				return false;
			}

			break;
		}
	}

	public static bool Boost(int playerNum)
	{

		switch (playerNum) {

		case 0:
			return Input.GetButton ("Boost_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetButton ("Boost_PS(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetButton ("Boost_XB(P" + playerNum + ")");
			} else {
				return false;
			}

			break;
		}
	}

	public static bool Check()
	{
		switch (defInput) {

		case 0:
			return Input.GetButton ("Check_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetButton ("Check_PS(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetButton ("Check_XB(P" + defInput + ")");
			} else {
				return false;
			}

			break;
		}
	}

	public static bool Check(int playerNum)
	{

		switch (playerNum) {

		case 0:
			return Input.GetButton ("Check_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetButton ("Check_PS(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetButton ("Check_XB(P" + playerNum + ")");
			} else {
				return false;
			}

			break;
		}
	}

	public static bool Shoot()
	{
		switch (defInput) {

		case 0:
			return Input.GetButton ("Shoot_KB");
			break;
		default:

			if (Input.GetJoystickNames () [defInput - 1] != null && Input.GetJoystickNames () [defInput - 1].Length == 19) {
				return Input.GetButton ("Shoot_PS(P" + defInput + ")");
			} else if (Input.GetJoystickNames () [defInput - 1] != null) {
				return Input.GetButton ("Shoot_XB(P" + defInput + ")");
			} else {
				return false;
			}

			break;
		}
	}

	public static bool Shoot(int playerNum)
	{

		switch (playerNum) {

		case 0:
			return Input.GetButton ("Shoot_KB");
			break;
		default:

			if (Input.GetJoystickNames () [playerNum - 1] != null && Input.GetJoystickNames () [playerNum - 1].Length == 19) {
				return Input.GetButton ("Shoot_PS(P" + playerNum + ")");
			} else if (Input.GetJoystickNames () [playerNum - 1] != null) {
				return Input.GetButton ("Shoot_XB(P" + playerNum + ")");
			} else {
				return false;
			}

			break;
		}
	}
}
