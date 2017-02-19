using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public PlayerControllers pc;
	public Text timerLabel;

	private float time;
	public static float minutes;
	public static float seconds;
	public static float milliseconds;

	bool completedWriteToFile = false;

	void Start() {
		minutes = 0;
		seconds = 0;
		milliseconds = 0;
	}

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
			if (!completedWriteToFile) {
				try {
					StreamReader sr = new StreamReader ("Assets\\Scripts\\scoreFile.txt");
					var line = sr.ReadLine ();
					sr.Close ();
					if (line != null) {
						time += Time.deltaTime;

						minutes = time / 60; 
						seconds = time % 60;
						milliseconds = (time * 100) % 100;
						timerLabel.text = string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);	

						var topMinutes = Int32.Parse(line.Substring(0, 2));
						var topSeconds = Int32.Parse(line.Substring(3, 2));
						var topMilliseconds = Int32.Parse(line.Substring(6, 2));
						if ((Math.Round(minutes) > topMinutes) ||
							(Math.Round(minutes) >= topMinutes && Math.Round(seconds) > topSeconds) ||
							(Math.Round(minutes) >= topMinutes && Math.Round(seconds) >= topSeconds && Math.Round(milliseconds) > topMilliseconds)) {
							WriteToFile();	
						} 
					} else {
						WriteToFile ();
					}
					completedWriteToFile = true;
				} catch (IOException e) {
					Debug.Log ("Exception: " + e.Message);
				}

				//Change scene
				SceneManager.LoadScene("GameOver");

			}

		}

	}

	void WriteToFile() {
		StreamWriter sw = new StreamWriter("Assets\\Scripts\\scoreFile.txt");
		//sw.WriteLine(string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds));
		sw.WriteLine(string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds));
		sw.Close();
	}
}
