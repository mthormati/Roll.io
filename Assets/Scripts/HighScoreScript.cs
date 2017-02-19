using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

	public Text highScoreText;
	public Text playerScore;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		try {
			StreamReader sr = new StreamReader ("Assets\\Scripts\\scoreFile.txt");
			string line = sr.ReadLine();
			highScoreText.text = line;
			playerScore.text = string.Format ("{0:00}:{1:00}:{2:00}", Timer.minutes, Timer.seconds, Timer.milliseconds);
			sr.Close();
		} catch (IOException e) {
			Debug.Log ("e: " + e.Message);
		}
	}

	public void OnClick() {
		Application.LoadLevel (0);
	}
}
