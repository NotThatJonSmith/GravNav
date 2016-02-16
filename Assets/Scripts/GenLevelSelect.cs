using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenLevelSelect : MonoBehaviour {

	public GameObject levelTilePrefab;
	private int tilesPerRow = 8;
	private int tileOffset = 90;
	private int vertOffset = 140;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		int tilesThisRow = 1;
		Vector3 anchor = new Vector3(Screen.width / 2 - (tilesPerRow-1) * tileOffset/2,
									 Screen.height - vertOffset,
									 0);
		Vector3 pos = anchor;
		print(SceneManager.sceneCountInBuildSettings);
		// Requires that the level select scene is build index 0!
		for (int i = 2; i < SceneManager.sceneCountInBuildSettings; i++) {
			GameObject lt = Instantiate(levelTilePrefab) as GameObject;
			lt.transform.SetParent(transform, true);
			RectTransform rt = lt.GetComponent<RectTransform>();
			if (rt == null) print("no recttransform in the tile prefab");
			Text txt = lt.GetComponentInChildren<Text>();
			if (txt == null) print("no text in the tile prefab");
			LevelTile lt_script = lt.GetComponent<LevelTile>();
			if (lt_script == null) print("no leveltile script in the tile prefab");

			rt.position = pos;
			txt.text = (i-1).ToString();
			lt_script.sceneIdx = i;
			if (tilesThisRow == tilesPerRow) {
				tilesThisRow = 1;
				pos.y -= tileOffset;
				pos.x = anchor.x;
			} else {
				pos.x += tileOffset;
				tilesThisRow++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
