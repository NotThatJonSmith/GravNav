using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour {

    public float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - startTime >= 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
