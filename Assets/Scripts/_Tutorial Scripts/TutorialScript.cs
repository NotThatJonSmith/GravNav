using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialScript : MonoBehaviour {

	public Canvas tutorialCanvas;
    private List<GameObject> curHighlights;

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

	public void showTutorial(List<GameObject> highlights) {
		Time.timeScale = 0;
		tutorialCanvas.enabled = true;
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
