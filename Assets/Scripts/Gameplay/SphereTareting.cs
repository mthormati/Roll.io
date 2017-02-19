using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTareting : MonoBehaviour {

    public GameObject target;
    public GameObject sphere;
    Rigidbody rb;
    Rigidbody targetRb;
    Vector3 fullVector;
    Vector3 unitVector;
    public float acceleration;
    private float force;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = sphere.GetComponent<Rigidbody>();
        targetRb = target.GetComponent<Rigidbody>();
        force = rb.mass * acceleration;
    }

    private void FixedUpdate()
    {
        fullVector = new Vector3(target.transform.position.x-sphere.transform.position.x, 0, target.transform.position.z - sphere.transform.position.z);
        unitVector = fullVector / fullVector.magnitude;
        if (Mathf.Abs(unitVector.x) * force < rb.velocity.x) unitVector.x *= 2;
        if (Mathf.Abs(unitVector.z) * force < rb.velocity.z) unitVector.z *= 2;
        rb.AddForce(unitVector * force);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
