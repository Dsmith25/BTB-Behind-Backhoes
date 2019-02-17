using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

	public GameObject target;
	//Smooth
	private float pX;
	private float pY;
	private float pZ;

	//Rotation
	public float turnSpeed = 10f; 	//How quickly the object will rotate while following
	public float viewAngle = 10f;	//rotates the object about the x axis; used for camera view angle

	//Position
	private Vector3 offset;
	public float speed = 10f;  		//How quickly the object will moe while following

	//Follow Settings:
	public bool isInstant = false;	//Stops Lerping/Slerping and translates/rotates instantly

	void Awake () {
		offset = transform.position - target.transform.position; //sets the offset to what it is in the editor
	}

	void FixedUpdate () {
		Follow ();
		Rotate ();
	}

	void LateUpdate()
	{
		Smooth ();
	}

	void Follow()
	{
		if (isInstant) {
			transform.position = target.transform.position + (target.transform.rotation * offset);
		} else {
			transform.position = Vector3.Lerp (transform.position, target.transform.position + (target.transform.rotation * offset), Time.deltaTime * speed);
		}

	}

	void Rotate()
	{

		Quaternion lookTarget = Quaternion.LookRotation (target.transform.position - transform.position, target.transform.up);

		if (isInstant) {
			transform.rotation = lookTarget;
		} else {
			transform.rotation = Quaternion.Slerp (transform.rotation, lookTarget, Time.deltaTime * turnSpeed);
		}
	}

	void Smooth()
	{
		pX = target.transform.eulerAngles.x;
		pY = target.transform.eulerAngles.y;
		pZ = target.transform.eulerAngles.z;
		
		transform.eulerAngles = new Vector3 ((pX + viewAngle) - pX, pY, pZ - pZ);
	}
}
