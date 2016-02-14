using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTile : MonoBehaviour {

	public int sceneIdx;

	public void onClick() {
		SceneManager.LoadScene(sceneIdx);
	}
}
