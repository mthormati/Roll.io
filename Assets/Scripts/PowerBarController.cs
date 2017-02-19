using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarController : MonoBehaviour {


	public Image powerBar;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 slidePos = Camera.main.WorldToScreenPoint (this.transform.position);
		powerBar.transform.position = slidePos;

	}


}
