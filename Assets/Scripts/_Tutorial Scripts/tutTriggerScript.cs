using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class tutTriggerScript : MonoBehaviour {

	public GameObject tutorialObject;
	public GameObject textObject;
    public List<GameObject> highlights;
    public bool ____________________________;
	public string textValue;
	public bool beenTriggered;

	// Use this for initialization
	void Start () {
		beenTriggered = false;
	}

	void OnTriggerEnter(Collider other)
	{
		// Can only be triggered once
		if (!beenTriggered && other.tag == "Player") {
			textObject.GetComponent<Text> ().text = textValue;
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
