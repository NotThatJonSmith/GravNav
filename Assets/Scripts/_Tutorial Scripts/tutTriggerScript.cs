using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class tutTriggerScript : MonoBehaviour {

	public GameObject tutorialObject;
	public GameObject textObject;
	public bool beenTriggered;
    public List<GameObject> highlights;
	public bool isTouch;
	[Header("Windows Values:")]
	public string textValue;
	[Header("Touch Values")]
	public bool reqUniqueText; // Has a unique text value
	public string touchTextValue;

	// Use this for initialization
	void Start () {
		// Check what platform the game is running on
		if (Application.platform == RuntimePlatform.Android ||
		    Application.platform == RuntimePlatform.IPhonePlayer) {
			isTouch = true;
		} else {
			isTouch = false;
		}

		beenTriggered = false;
	}

	void OnTriggerEnter(Collider other)
	{
		// Can only be triggered once
		if (!beenTriggered && other.tag == "Player") {
			// Show different text values depending on platform
			if (isTouch && reqUniqueText) {
				textObject.GetComponent<Text> ().text = touchTextValue;
			} else {
				textObject.GetComponent<Text> ().text = textValue;
			}
			tutorialObject.GetComponent<TutorialScript> ().showTutorial (highlights);
			beenTriggered = true;
            foreach(GameObject planet in highlights)
            {
                Behaviour halo = (Behaviour) planet.GetComponent("Halo");
                halo.enabled = true;
            }
        }
	}
}
