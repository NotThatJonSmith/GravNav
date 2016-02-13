using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum buttonIndex {up = 0, down, left, right, size};

public class BoostUIScript : MonoBehaviour {

	public Canvas boostCanvas;
	public Button[] boostButtons = new Button[(int)buttonIndex.size];

	GameObject player;

	// Use this for initialization
	void Start () {
		player = PlayerScript.S.gameObject;

		updateButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		updateButtons ();
		if (player.active == false)
			boostCanvas.enabled = false;
	}

	// i cant believe how ugly this is lol
	void updateButtons() {
        if (PlayerScript.S)
        {
            boostButtons[(int)buttonIndex.up].GetComponent<BoostButtonScript>().updateNumValue(player.GetComponent<Thruster>().upUses);
            boostButtons[(int)buttonIndex.down].GetComponent<BoostButtonScript>().updateNumValue(player.GetComponent<Thruster>().downUses);
            boostButtons[(int)buttonIndex.left].GetComponent<BoostButtonScript>().updateNumValue(player.GetComponent<Thruster>().leftUses);
            boostButtons[(int)buttonIndex.right].GetComponent<BoostButtonScript>().updateNumValue(player.GetComponent<Thruster>().rightUses);
        }
	}
}
