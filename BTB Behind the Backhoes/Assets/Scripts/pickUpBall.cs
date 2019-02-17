using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpBall : MonoBehaviour
{
    public bool ballPoss = false;
    public GameObject fakeBall;
	public GameObject player;
	public int playerNum = 0;

	private GameObject ball;
	private float shotForce = 20f;
    
	// Use this for initialization
	void Start ()
    {
        
	}

    // Update is called once per frame
    void Update()
    {
		if (ballPoss && InputManager.Shoot (playerNum)) {
			Shoot ();
		}
    }

	public void Drop(Vector3 dir)
	{
		ballPoss = false;
		fakeBall.SetActive (false);
		ball.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 2);
		ball.SetActive (true);
		ball.GetComponent<Rigidbody> ().AddForce ((1f + Mathf.Clamp(player.GetComponent<Rigidbody>().velocity.magnitude, -shotForce, shotForce)) * dir, ForceMode.Impulse);
		ball.GetComponent<ballPhysics> ().canPickUp = false;
		ball = null;
	}

	void Shoot() {
		ballPoss = false;
		fakeBall.SetActive (false);
		ball.transform.position = new Vector3 (this.transform.position.x, 7f, this.transform.position.z);
		ball.SetActive (true);
		ball.GetComponent<Rigidbody> ().AddForce ((shotForce + Mathf.Clamp(player.GetComponent<Rigidbody>().velocity.magnitude, -shotForce, shotForce)) * -this.transform.forward, ForceMode.Impulse);
		ball = null;
	}

	void pickUp()
    {
		ball.SetActive (false);
		ball.transform.position = new Vector3 (0,-10,0);
		ball.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		ball.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, 0);
		fakeBall.SetActive(true);
       ballPoss = true;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "ball")
        {
			if (coll.gameObject.GetComponent<ballPhysics> () != null && coll.gameObject.GetComponent<ballPhysics> ().canPickUp) {
				this.ball = coll.gameObject;
				pickUp (); 
			}
        }

		if (coll.gameObject.layer == 13) {
			if (player.GetComponentInChildren<RotateBody> ().isChecking) {
				coll.gameObject.GetComponent<pickUpBall> ().Drop (player.transform.forward);//new Vector3(player.transform.forward.x, 10f, player.transform.forward.z));
			}
		}
    }
}
