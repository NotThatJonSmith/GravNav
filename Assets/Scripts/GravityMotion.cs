using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravityMotion : MonoBehaviour {
	
	public Rigidbody rigid;
	public PlanetScript[] attractors;
	public int power = 1;
	public int multiplier = 1;

	void Start() {
		rigid = GetComponent<Rigidbody>();
		if (rigid == null) print("Error! No Rigidbody component found");
		attractors = FindObjectsOfType<PlanetScript>();
	}

	public bool isFloating;
	void FixedUpdate() {
		bool isFloatingTemp = true;
		foreach (PlanetScript ps in attractors) {
			if (ps.disableForce) continue;
			rigid.AddForce(gravity(ps, transform.position));
			isFloatingTemp = false;
		}
		isFloating = isFloatingTemp;
	}

	public Vector3 gravity(PlanetScript ps, Vector3 pos) {
		Vector3 displacement = ps.gameObject.transform.position - pos;
		return multiplier * displacement.normalized * ps.strengthOfAttraction / Mathf.Pow(displacement.magnitude, power);
	}
}
