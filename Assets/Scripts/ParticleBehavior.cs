using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour {

	private float vertExtent;
	private float horzExtent;
	private Rigidbody rigid;

	void Start() {
		vertExtent = Camera.main.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height;
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error: No Rigidbody on particle");
		rigid.velocity = Random.onUnitSphere;
	}

	void OnTriggerEnter() {
		Destroy(gameObject);
	}

	void Update() {
		if (transform.position.x > horzExtent ||
			transform.position.x < -horzExtent ||
			transform.position.y > vertExtent ||
			transform.position.y < -vertExtent)
			Destroy(gameObject);
	}
}
