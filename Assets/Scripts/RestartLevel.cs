﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartLevel : MonoBehaviour {
    public KeyCode resetKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(resetKey)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("level_select");
		}
	}
}
