using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityMotion : MonoBehaviour {
	
	private Rigidbody rigid;
	public PlanetScript[] attractors;
	public Vector3 lastAppliedForce; // for debug
	public LineRenderer lr;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error! No Rigidbody component found");
	}

	void FixedUpdate() {
		foreach (PlanetScript ps in attractors) {
			if (ps.disableForce) continue;
			lastAppliedForce = gravity(ps, transform.position);
			rigid.AddForce(lastAppliedForce);
		}
	}

	void OnCollisionEnter(Collision coll) {
		Destroy(gameObject);
	}


	public static Vector3 gravity(PlanetScript ps, Vector3 pos) {
		Vector3 displacement = ps.gameObject.transform.position - pos;
		return displacement.normalized * ps.strengthOfAttraction / displacement.magnitude;
	}
}
