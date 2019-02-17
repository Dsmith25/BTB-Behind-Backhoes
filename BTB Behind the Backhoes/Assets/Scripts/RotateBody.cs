using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour {

	public float turnSpeed = 100;
	public float checkTime = 1;

    public int playerNum;

	public bool isChecking = false;
	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if ( !isChecking && InputManager.Check(playerNum) ) {
			StartCoroutine( Check() );
		}
			
	}

	void FixedUpdate () {
		if (!isChecking) {
			Turn ();
		}
	}

	IEnumerator Check()
	{
		isChecking = true;

		float time = 0f;
		while (time < checkTime) {
			time += Time.deltaTime;
			transform.Rotate (new Vector3(0, 360 / checkTime, 0) * Time.deltaTime);
			yield return null;
		}
		isChecking = false;
	}

	void Turn () {

		float turn = InputManager.AltHorizontal(playerNum) * turnSpeed * Time.deltaTime;

		Vector3 turnRotation = new Vector3 (0f, turn, 0f);

		transform.Rotate (turnRotation);
	}
}
