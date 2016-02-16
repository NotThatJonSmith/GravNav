using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialScript : MonoBehaviour {

	public Canvas tutorialCanvas;
    private List<GameObject> curHighlights;
	public bool isTouch;
	public float tutorialTime;
	float tutTriggeredTime;

	// Use this for initialization
	void Start () {
		// Check what platform the game is running on
		if (Application.platform == RuntimePlatform.Android ||
			Application.platform == RuntimePlatform.IPhonePlayer) {
			isTouch = true;
		} else {
			isTouch = false;
		}
			
		disableTutorial ();
	}

	void Update() {
		// If tutorial is enabled >_>
		if (tutorialCanvas.enabled == true) {
			// Disable if mouse click anywhere
			if (Input.GetMouseButtonDown (0)) {
				disableTutorial ();
			}

			// If it's touch device, then have a countdown timer for tutorial to go away
			if (isTouch) {
				if ((Time.realtimeSinceStartup - tutTriggeredTime) >= tutorialTime)
					disableTutorial ();
			}
		}
	}

	public void showTutorial(List<GameObject> highlights) {
		Time.timeScale = 0;
		tutorialCanvas.enabled = true;
		tutTriggeredTime = Time.realtimeSinceStartup;

        curHighlights = new List<GameObject>(highlights);
	}

	public void disableTutorial() {
		Time.timeScale = 1;
		tutorialCanvas.enabled = false;

        if (curHighlights != null)
        {
            foreach (GameObject planet in curHighlights)
            {
                Behaviour halo = (Behaviour)planet.GetComponent("Halo");
                if (halo)
                {
                    halo.enabled = false;
                }
            }
        }
	}
		
}
