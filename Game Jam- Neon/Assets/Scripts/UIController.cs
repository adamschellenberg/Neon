using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text timerText;

	public float time;

	string minutes;
	string seconds;

	// Use this for initialization
	void Start () {
		time = 118;

	}
	
	// Update is called once per frame
	void Update () {
		timerText.text = "Time: " + minutes + ":" + seconds;
		CountDown ();
		if (time <= 0) {
			EndGame ();
		}

	}

	void CountDown() {
		time -= Time.deltaTime;
		minutes = Mathf.Floor (time / 60).ToString ("00");
		seconds = (time % 60).ToString ("00");
	}

	void EndGame(){
		
	}
}
