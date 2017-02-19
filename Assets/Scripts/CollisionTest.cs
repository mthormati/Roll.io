using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    public GameObject other;
    Rigidbody rb;
    ContactPoint point;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            explosion(collision);
        }
    }
    void explosion(Collision collision)
    {
        
            point = collision.contacts[0];
            rb = other.GetComponent<Rigidbody>();
            Debug.Log(point.point);
            rb.AddExplosionForce(25000, point.point, 10);
    }

    public float acceleration;
    public float maxSpeed;
    private float force;

    // Use this for initialization
    void Awake()
    {
        rb = other.GetComponent<Rigidbody>();
        force = rb.mass * acceleration;
    }

    // Use this for initialization
    private void FixedUpdate()
    {
       // rb.AddForce(new Vector3(-force, 0, 0));
    }
    // Update is called once per frame
    void Update () {
		
	}
}
