using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballPhysics : MonoBehaviour
{
    public float gravityMult = 5f;
	public bool canPickUp = true;

	private float cantPickUpTime = 1f;
	void Update()
	{
		if (!canPickUp) {
			StartCoroutine (Dropped ());
		}
	}

    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(Physics.gravity*gravityMult, ForceMode.Acceleration);
        
    }

	IEnumerator Dropped()
	{
		float time = 0f;

		while (time < cantPickUpTime) {
			time += Time.deltaTime;
			yield return null;
		}


		canPickUp = true;
	}
}
