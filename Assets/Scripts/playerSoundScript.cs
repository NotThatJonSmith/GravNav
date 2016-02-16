using UnityEngine;
using System.Collections;

public class playerSoundScript : MonoBehaviour {

	AudioSource playerAS;
	Rigidbody	playerRigidbody;

	public float maxSpeedForMaxPitch;

	// Use this for initialization
	void Start () {
		playerAS = GetComponent<AudioSource> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	// p0(1-u) + p1(u)
	// p0 = 0.5f
	// p1 = 3.0f

	// Update is called once per frame
	void Update () {
		if (playerRigidbody.velocity.magnitude <= maxSpeedForMaxPitch) {
			playerAS.pitch = 0.5f * (1f - playerRigidbody.velocity.magnitude/maxSpeedForMaxPitch) +
							 3.0f * (playerRigidbody.velocity.magnitude/maxSpeedForMaxPitch);
		} 
		else {
			playerAS.pitch = 3.0f;
		}
	}
}
