using UnityEngine;
using System.Collections;

public enum music {levelSelect, tutorial, level, size};

public class BGMusicScript : MonoBehaviour {

	// mainCamera holds song info
	public GameObject mainCamera;
	public AudioClip[] songList = new AudioClip[(int)music.size];
	music currentPlayingMusic;

	// Use this for initialization
	void Start () {
		// Make this persistant across all levels
		DontDestroyOnLoad (this);

		mainCamera = Camera.main.gameObject;

		currentPlayingMusic = mainCamera.GetComponent<CurrentLevelSong> ().currentLevelMusic;
		playSong (mainCamera.GetComponent<CurrentLevelSong> ().currentLevelMusic);
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera = Camera.main.gameObject;

		print (mainCamera.GetComponent<CurrentLevelSong>().currentLevelMusic);
		if (mainCamera.GetComponent<CurrentLevelSong> ().currentLevelMusic != currentPlayingMusic) {
			playSong (mainCamera.GetComponent<CurrentLevelSong> ().currentLevelMusic);
			currentPlayingMusic = mainCamera.GetComponent<CurrentLevelSong> ().currentLevelMusic;
		}
	}

	void playSong(music type) {
		GetComponent<AudioSource> ().clip = songList [(int)type];
		GetComponent<AudioSource> ().Play ();
	}
}
