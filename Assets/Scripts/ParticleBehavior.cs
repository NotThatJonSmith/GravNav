using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour {

	private float vertExtent;
	private float horzExtent;
	private Rigidbody rigid;
	private GravityMotion gm;

	void Start() {
		vertExtent = Camera.main.orthographicSize;
		horzExtent = vertExtent * Screen.width / Screen.height;
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error: No Rigidbody on particle");
		gm = GetComponent<GravityMotion>();
		if (gm == null) print("Error: No GravityMotion on particle");
		rigid.velocity = Random.onUnitSphere;
	}

	void OnTriggerEnter() {
		Destroy(gameObject);
	}

	public bool wasFloating = true;
	void Update() {
		if (!wasFloating && gm.isFloating && rigid.velocity.magnitude > 1f) {
			rigid.velocity = rigid.velocity.normalized * Random.value;
		}
		wasFloating = gm.isFloating;
		if (transform.position.x > horzExtent ||
			transform.position.x < -horzExtent ||
			transform.position.y > vertExtent ||
			transform.position.y < -vertExtent)
			Destroy(gameObject);
	}
}
