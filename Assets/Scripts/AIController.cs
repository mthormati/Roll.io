using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {


	public float acceleration;
	public GameObject AIBall;
	Rigidbody rb;

	// Use this for initialization
	void Start(){
		rb = AIBall.GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 movement = new Vector3 (-acceleration, 0, 0);
		rb.AddForce (movement);
	}
}
