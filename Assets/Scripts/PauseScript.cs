using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	public Canvas pauseCanvas;
	public GameObject[] everythingNotPauseButton;
	public GameObject pauseButton;
	bool isPaused;

	// Use this for initialization
	void Start () {
		unpause ();
		pauseButton.SetActive (true);
	}

	void Update() {
		if (!PlayerScript.S.gameObject.active)
			pauseCanvas.enabled = false;
	}

	// Custom function for pauseButton
	public void pauseButtonClick() {
		if (isPaused)
			unpause ();
		else
			pause ();
	}

	public void unpause() {
		foreach (GameObject canvasObject in everythingNotPauseButton) {
			canvasObject.SetActive (false);
		}
		isPaused = false;
		Time.timeScale = 1;
	}

	public void pause() {
		foreach (GameObject canvasObject in everythingNotPauseButton) {
			canvasObject.SetActive (true);
		}
		isPaused = true;
		Time.timeScale = 0;
	}

	public void restartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void levelSelect() {
		SceneManager.LoadScene ("level_select");
	}
}
