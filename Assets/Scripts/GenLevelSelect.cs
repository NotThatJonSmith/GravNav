using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenLevelSelect : MonoBehaviour {

	public GameObject levelTilePrefab;
	public int tilesPerRow = 7;
	public int tileOffset = 40;
	public int vertOffset = 80;

	// Use this for initialization
	void Start () {
		int tilesThisRow = 1;
		Vector3 anchor = new Vector3(Screen.width / 2 - (tilesPerRow-1) * tileOffset/2,
									 Screen.height - vertOffset,
									 0);
		Vector3 pos = anchor;
		print(SceneManager.sceneCountInBuildSettings);
		// Requires that the level select scene is build index 0!
		for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
			GameObject lt = Instantiate(levelTilePrefab) as GameObject;
			lt.transform.SetParent(transform, true);
			RectTransform rt = lt.GetComponent<RectTransform>();
			if (rt == null) print("no recttransform in the tile prefab");
			Text txt = lt.GetComponentInChildren<Text>();
			if (txt == null) print("no text in the tile prefab");
			LevelTile lt_script = lt.GetComponent<LevelTile>();
			if (lt_script == null) print("no leveltile script in the tile prefab");

			rt.position = pos;
			txt.text = i.ToString();
			lt_script.sceneIdx = i;
			if (tilesThisRow == tilesPerRow) {
				tilesThisRow = 1;
				pos.y -= 40;
				pos.x = anchor.x;
			} else {
				pos.x += 40;
				tilesThisRow++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
