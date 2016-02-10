using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityMotion : MonoBehaviour {
	
	public Rigidbody rigid;
	public PlanetScript[] attractors;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error! No Rigidbody component found");
		attractors = FindObjectsOfType<PlanetScript>();
	}

	void FixedUpdate() {
		foreach (PlanetScript ps in attractors) {
			if (ps.disableForce) continue;
			rigid.AddForce(gravity(ps, transform.position));
		}
	}

	public static Vector3 gravity(PlanetScript ps, Vector3 pos) {
		Vector3 displacement = ps.gameObject.transform.position - pos;
		return displacement.normalized * ps.strengthOfAttraction / displacement.magnitude;
	}
}
