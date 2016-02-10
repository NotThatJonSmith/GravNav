using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour {

	public void restartLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void nextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
