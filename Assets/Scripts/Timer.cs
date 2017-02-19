using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Timer : MonoBehaviour {

	public PlayerController pc;
	public Text timerLabel;

	private float time;
	private float minutes;
	private float seconds;
	private float milliseconds;

	void Update() {
		if (!pc.isGameOver ()) {
			time += Time.deltaTime;

			minutes = time / 60; 
			seconds = time % 60;
			milliseconds = (time * 100) % 100;

			if (milliseconds > 99) {
				milliseconds = 0;
			}

			//update the label value
			timerLabel.text = string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);	
		} else {
			try {
				StreamReader sr = new StreamReader("Assets\\Scripts\\scoreFile.txt");
				var line = sr.ReadLine();
				sr.Close();

				StreamWriter sw = new StreamWriter("Assets\\Scripts\\scoreFile.txt");
				//sw.WriteLine(string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds));
				sw.WriteLine(string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds));

				sw.Close();
			} catch (IOException e) {
				Debug.Log ("Exception: " + e.Message);
			}
		}

	}
}
