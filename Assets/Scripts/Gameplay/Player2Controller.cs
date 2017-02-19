using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

	public GameObject player;
	Rigidbody rb;

	public float acceleration;
	public float maxSpeed;

	// Use this for initialization
	void Awake () {
		rb = player.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftArrow)) rb.AddForce(new Vector3(-acceleration, 0, 0));
		if (Input.GetKey(KeyCode.RightArrow)) rb.AddForce(new Vector3(acceleration, 0, 0));
		if (Input.GetKey(KeyCode.UpArrow)) rb.AddForce(new Vector3(0, 0, acceleration));
		if (Input.GetKey(KeyCode.DownArrow)) rb.AddForce(new Vector3(0, 0, -acceleration));

	}
}
