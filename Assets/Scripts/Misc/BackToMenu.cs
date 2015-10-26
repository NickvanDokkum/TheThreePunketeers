using UnityEngine;
using System.Collections;

public class BackToMenu : MonoBehaviour {

	public int time;
	bool timer = false;

	void Start () {
		Invoke ("BackToThatMenu", time);
		Invoke ("Timer", 2);
	}
	void Update(){
		if (Input.anyKeyDown && timer == true) {
			BackToThatMenu();
		}
	}
	void Timer(){
		timer = true;
	}
	void BackToThatMenu () {
		Application.LoadLevel (0);
	}
}
