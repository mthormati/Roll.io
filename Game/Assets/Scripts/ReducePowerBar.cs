using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducePowerBar : MonoBehaviour {

	//public float TotalPower;
	//public static float CurrentPower;
	// Use this for initialization
	void Start () {
		//CurrentPower = TotalPower;

	}


	void BoostPower(){
		PlayerControllers.durability -= 1;
		transform.localScale = new Vector3 ((PlayerControllers.durability / PlayerControllers.maxDurability),1,1);
	}

	void ReducePower(){
		PlayerControllers.durability -= 5;
		transform.localScale = new Vector3 ((PlayerControllers.durability / PlayerControllers.maxDurability),1,1);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			ReducePower ();
		}
	}

	void FixedUpdate(){
		transform.localScale = new Vector3 ((PlayerControllers.durability / PlayerControllers.maxDurability),1,1);
		if (PlayerControllers.durability > 1) {
			if (Input.GetKey (KeyCode.Space)) {
				BoostPower ();
			}
		} else {
			Debug.Log ("No more");
		}

	}
}
