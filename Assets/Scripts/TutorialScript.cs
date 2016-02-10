using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {

	public Canvas tutorialCanvas;

	// Use this for initialization
	void Start () {
		disableTutorial ();
	}

	void Update() {
		// If tutorial is enabled >_>
		if (tutorialCanvas.enabled == true) {
			// Disable if mouse click anywhere
			if (Input.GetMouseButtonDown (0)) {
				disableTutorial ();
			}
		}
	}

	public void showTutorial() {
		Time.timeScale = 0;
		tutorialCanvas.enabled = true;
	}

	public void disableTutorial() {
		Time.timeScale = 1;
		tutorialCanvas.enabled = false;
	}
		
}
