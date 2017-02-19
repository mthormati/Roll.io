using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject player;
	Rigidbody rb;

	public static float maxDurability = 1000;
	public static float durability;

	//public static float maxDura;
	public float duraMult;

	ContactPoint point;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Ground")
		{
			avoided = false;
			countdown = timer;
			durability *= 1/duraMult;
			point = collision.contacts[0];
			// rb = player.GetComponent<Rigidbody>();
			Debug.Log(durability);
			rb.AddExplosionForce(2500000/durability, point.point, 10);
			//transform.localScale = new Vector3 ((durability / maxDurability),1,1);
		
		}
	}

	private bool avoided = true;

	private float timer = 80;
	private float countdown;

	public float acceleration;
	public float maxSpeed;
	private float force;

	public float boostup;



	private void Start()
	{
		/*maxDura = 1;
		durability = 100;*/
		durability = maxDurability;
		countdown = timer;
	}

	// Use this for initialization
	void Awake () {
		rb = player.GetComponent<Rigidbody>();
		force = rb.mass * acceleration;

	}

	void FixedUpdate()
	{
		
		if (Input.GetAxis ("Horizontal") < 0) {
			if (rb.velocity.x > 0)
				rb.AddForce (-3 * force, 0, 0);
			else
				rb.AddForce (new Vector3 (-force, 0, 0));
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			if (rb.velocity.x < 0)
				rb.AddForce (3 * force, 0, 0);
			else
				rb.AddForce (new Vector3 (force, 0, 0));
		}
		if (Input.GetAxis ("Vertical") > 0) {
			if (rb.velocity.z < 0)
				rb.AddForce (0, 0, 3 * force);
			else
				rb.AddForce (new Vector3 (0, 0, force));
		}
		if (Input.GetAxis ("Vertical") < 0) {
			if (rb.velocity.z > 0)
				rb.AddForce (0, 0, -3 * force);
			else
				rb.AddForce (new Vector3 (0, 0, -force));
		}

		if (durability > 0) {
			if (Input.GetKey (KeyCode.Space) && Input.GetAxis ("Horizontal") < 0) {
				rb.AddForce (new Vector3 (-acceleration, 0, 0) * boostup);
			}
			if (Input.GetKey (KeyCode.Space) && Input.GetAxis ("Vertical") > 0) {
				rb.AddForce (new Vector3 (0, 0, acceleration) * boostup);
			}
			if (Input.GetKey (KeyCode.Space) && Input.GetAxis ("Horizontal") > 0) {
				rb.AddForce (new Vector3 (acceleration, 0, 0) * boostup);
			}
			if (Input.GetKey (KeyCode.Space) && Input.GetAxis ("Vertical") < 0) {
				rb.AddForce (new Vector3 (0, 0, -acceleration) * boostup);
			}
		} else {
			Debug.Log ("Can't");
		}

	
		countdown--;
		if (countdown <= 0)
		{
			countdown = timer;
			if (avoided && durability < 1000) durability += .1f;
			if (durability > 1000) durability = 1000;
			avoided = true;
		}

	}

	// Update is called once per frame
	void Update () {

	}
}
