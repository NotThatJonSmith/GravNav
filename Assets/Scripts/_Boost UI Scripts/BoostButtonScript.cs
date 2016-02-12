using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoostButtonScript : MonoBehaviour {

	public buttonIndex buttonType;
	public Text buttonText;

	// Use this for initialization
	void Start () {
		if (buttonType == buttonIndex.up)
			this.GetComponent<Button> ().onClick.AddListener (PlayerScript.S.GetComponent<Thruster>().upBoost);
		if (buttonType == buttonIndex.down)
			this.GetComponent<Button> ().onClick.AddListener (PlayerScript.S.GetComponent<Thruster>().downBoost);
		if (buttonType == buttonIndex.left)
			this.GetComponent<Button> ().onClick.AddListener (PlayerScript.S.GetComponent<Thruster>().leftBoost);
		if (buttonType == buttonIndex.right)
			this.GetComponent<Button> ().onClick.AddListener (PlayerScript.S.GetComponent<Thruster>().rightBoost);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void updateNumValue(int newNum) {
		buttonText.text = newNum.ToString ();
	}
}
