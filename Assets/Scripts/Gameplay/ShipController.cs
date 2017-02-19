using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public GameObject player;
    Rigidbody rb;

    public static float maxDurability = 1000;

    public static float durability;
    float maxDura;
    public float duraMult;

    ContactPoint point;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            avoided = false;
            countdown = timer;
            if (!(durability <= 1)) durability *= 1 / duraMult;
            point = collision.contacts[0];
            // rb = player.GetComponent<Rigidbody>();
            Debug.Log(point.point);
            rb.AddExplosionForce(250000 / durability, point.point, 10);
        }
    }
    public float dura;
    private bool avoided = true;
    public float timer = 10;
    private float countdown;

    public float acceleration;
    public float maxSpeed;
    private float force;

    public float boostup;



    private void Start()
    {
        countdown = timer;
        durability = maxDurability;
    }

    // Use this for initialization
    void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
        force = rb.mass * acceleration;
        //countdown = timer;
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime, Space.Self);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime, Space.Self);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            if (rb.velocity.z < 0) rb.AddForce(rb.transform.up * force * 5);
            else rb.AddForce(force * rb.transform.up);         
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            if (rb.velocity.z > 0) rb.AddForce(rb.transform.up * -force * 5);
            else rb.AddForce(-force * rb.transform.up);
        }

        if (durability > 0)
        {
            if (Input.GetKey(KeyCode.Space) && Input.GetAxis("Horizontal") < 0)
            {
                rb.AddForce(new Vector3(-acceleration, 0, 0) * boostup);
            }
            if (Input.GetKey(KeyCode.Space) && Input.GetAxis("Vertical") > 0)
            {
                rb.AddForce(new Vector3(0, 0, acceleration) * boostup);
            }
            if (Input.GetKey(KeyCode.Space) && Input.GetAxis("Horizontal") > 0)
            {
                rb.AddForce(new Vector3(acceleration, 0, 0) * boostup);
            }
            if (Input.GetKey(KeyCode.Space) && Input.GetAxis("Vertical") < 0)
            {
                rb.AddForce(new Vector3(0, 0, -acceleration) * boostup);
            }
        }
        else
        {
            Debug.Log("Can't");
        }

        countdown--;
        if (countdown <= 0)
        {
            countdown = timer;
            if (avoided && durability < 1000) durability += 250f;
            if (durability > 1000) durability = 1000;
            avoided = true;
        }
        dura = durability;

        if (rb.velocity.x > 10) rb.AddForce(-10*force, 0, 0);
        if (rb.velocity.x < -10) rb.AddForce(10*force, 0, 0);
        if (rb.velocity.y > 20) rb.AddForce(rb.transform.up * force * -10);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
