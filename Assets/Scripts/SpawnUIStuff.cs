using UnityEngine;
using System.Collections;

public class SpawnUIStuff : MonoBehaviour {

	public GameObject boostUI;
	public GameObject pauseUI;

	// Use this for initialization
	void Start () {
		Instantiate (boostUI);
		Instantiate (pauseUI);
	}
}
