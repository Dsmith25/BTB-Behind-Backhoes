//***********************************************************
// BTB Movement Script by R. Thomas James
// Please do not use without permission.
//***********************************************************

//Controls track movement and rotation on the backhoe
//Prevents the backhoe from flipping over
//Attach to the Parent Player # gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Rigidbody rig;
	Transform tran;
	public float acceleration = 5000;	//controls acceleration of the backhoe
	public float turnSpeed = 100;		//controls the speed of rotating the tracks
	public float speed;					//DON'T GIVE THIS A VALUE; It displays speed in m/s
	public float boost = 10000;         //acceleration of the backhoe while boosting 
                                        //(not stacked with normal acceleration)
    public int playerNum;			// Keyboard = 0; First Controller = 1; Second Controller = 2;

	private bool isBoosting = false;	//may need to be changed to public for energy
	private Vector3 correctionX;		//how forcibly the rotation corrects itself
	private Vector3 correctionZ;
	private int correctionDeadZone = 5; //How many euler degrees the backhoe has to be off center before correction starts

	void Awake () {
		rig = GetComponent<Rigidbody> ();
		tran = GetComponent<Transform> ();
		correctionX = new Vector3 (100, 0, 0);
		correctionZ = new Vector3 (0, 0, 100);
	}
	

	void Update () {
		if (InputManager.Boost(playerNum)) {		//use InputManager.[DesiredInput](playerNum) instead of Input.Get___
			isBoosting = true;			
		} else {
			isBoosting = false;
		}
			
	}

	void FixedUpdate () {
		Correct ();				//Correct Rotation
		Move ();				//Add movement (to and fro)
		Turn ();				//Turn tracks (not body)
		speed = rig.velocity.magnitude;		//Report the current speed

	}

	void Move () {	//moves tracks to and fro based on acceleration or boost depending on isBoosting
		Vector3 movement;

		if (isBoosting) {
			movement = InputManager.MainVertical(playerNum)* transform.forward * boost * Time.deltaTime;
		} else {
			movement = InputManager.MainVertical(playerNum) * transform.forward * acceleration * Time.deltaTime;
		}



		rig.AddForce (movement.x, 0, movement.z, ForceMode.Acceleration);
	}

	void Turn () {	//rotates tracks basesd on turnspeed
		float turn = InputManager.MainHorizontal(playerNum) * turnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		rig.MoveRotation (rig.rotation * turnRotation);
	}

	void Correct() {	//corrects x and z rotation of backhoe 
		Quaternion deltaRotationX = Quaternion.Euler (correctionX * Time.deltaTime);
		Quaternion deltaRotationZ = Quaternion.Euler (correctionZ * Time.deltaTime);

		Quaternion deltaRotationNX = Quaternion.Euler (-correctionX * Time.deltaTime);
		Quaternion deltaRotationNZ = Quaternion.Euler (-correctionZ * Time.deltaTime);

		if (tran.eulerAngles.x > (correctionDeadZone) && tran.eulerAngles.x < 180)
		{
			rig.MoveRotation(rig.rotation * deltaRotationNX);
		}

		if (tran.eulerAngles.x >= 180 && tran.eulerAngles.x < (360 - correctionDeadZone))
		{
			rig.MoveRotation(rig.rotation * deltaRotationX);
		}

		if (tran.eulerAngles.z > (correctionDeadZone) && tran.eulerAngles.z < 180)
		{
			rig.MoveRotation(rig.rotation * deltaRotationNZ);
		}

		if (tran.eulerAngles.z >= 180 && tran.eulerAngles.z < (360 - correctionDeadZone))
		{
			rig.MoveRotation(rig.rotation * deltaRotationZ);
		}
	}
}
